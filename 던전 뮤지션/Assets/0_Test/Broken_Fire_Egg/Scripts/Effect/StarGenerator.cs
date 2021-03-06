﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarGenerator : MonoBehaviour {

    public GameObject[] pool;
    public GameObject original;
	public int Max;
    public float delay;
    public Animator anitor;
    float flowT;
    AsyncOperation async;
    public bool useVector;
    public int timess;
    public Vector3 random;
    private void Awake()
    {
        flowT = 0f;
        pool = new GameObject[Max];
    }
    private void Start()
    {
        if (anitor != null)
            StartCoroutine(PreloadScene());
   //     async = SceneManager.LoadSceneAsync(4);
    //    async.allowSceneActivation = false;
    }
    
    // Update is called once per frame
    void Update () {
        flowT += Time.deltaTime;
        int times;
        if (timess == 0)
            times = Random.Range(1, 4);
        else
            times = timess;
        if (flowT >= delay)
        {
            while (times > 0)
            {
                for (int i = 0; i < Max; i++)
                {
                    if (pool[i] == null)
                    {
                        pool[i] = Instantiate(original, transform);
                        if (useVector)
                        {
                            pool[i].transform.localPosition = new Vector3(Random.Range(-random.x, random.x), Random.Range(-random.y, random.y)); 
                        }
                        else
                        {
                            pool[i].transform.localPosition = new Vector3(Random.Range(-540, 540), Random.Range(-180, 180));
                        }
                        break;
                    }
                }
                times--;
            }

            flowT -= delay;
        }
        if(anitor != null)
        if(Input.GetMouseButtonDown(0))
        {
            anitor.SetTrigger("Start");
            Invoke("SceneMove", 3f);
        }
	}
    public void SceneMove()
    {
        async.allowSceneActivation = true;
    }
    public IEnumerator PreloadScene()
    {
        yield return null;
        async = SceneManager.LoadSceneAsync(4, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while(async.progress != 0.9f)
        {

        }
        yield return async;
    }

}
