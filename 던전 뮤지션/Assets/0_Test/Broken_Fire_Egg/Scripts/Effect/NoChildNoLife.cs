using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoChildNoLife : MonoBehaviour {
    GameObject[] child;
    public GameObject[] Plus;
    public bool insteadOff;
    private void Start()
    {
        if (transform.childCount + Plus.Length == 0)
            Destroy(gameObject);
        child = new GameObject[transform.childCount + Plus.Length];
        int i = 0;
        for (i=0; i < transform.childCount;i++)
            child[i] = transform.GetChild(i).gameObject;
        for (int k = 0; k < Plus.Length; i++, k++)
            child[i] = Plus[k];
    }


    void Update()
    {
        bool delete = true;
        for (int i = 0; i < child.Length; i++)
        {
            if (child[i].activeInHierarchy == true)
                delete = false;
        }
        if (delete)
        {
            if (insteadOff)
                gameObject.SetActive(false);
            else
                Destroy(gameObject);
        }
    }
}
