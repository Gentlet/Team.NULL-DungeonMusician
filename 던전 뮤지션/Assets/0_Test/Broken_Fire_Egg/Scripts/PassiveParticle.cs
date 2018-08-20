using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveParticle : MonoBehaviour {

    public GameObject[] PS;
    int len;
    int curr;

    private void Start()
    {
        len = PS.Length;
        curr = 0;
    }


    public void ChangePassiveParticle(int n)
    {
        if(n < len)
        {
            PS[curr].SetActive(false);
            PS[n].SetActive(true);
            curr = n;
        }
    }
}
