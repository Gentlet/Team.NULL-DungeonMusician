using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarGenerator : MonoBehaviour {

    public GameObject[] pool;
    public GameObject original;
	public int Max;
    public float delay;
    float flowT;


    private void Awake()
    {
        flowT = 0f;
        pool = new GameObject[Max];
    }
    // Update is called once per frame
    void Update () {
        flowT += Time.deltaTime;
        int times = Random.Range(1,4);
        if (flowT >= delay)
        {
            while (times > 0)
            {
                for (int i = 0; i < Max; i++)
                {
                    if (pool[i] == null)
                    {
                        pool[i] = Instantiate(original, transform);
                        pool[i].transform.localPosition = new Vector3(Random.Range(-540, 540), Random.Range(-180, 180));
                        break;
                    }
                }
                times--;
            }

            flowT -= delay;
        }
       
	}
}
