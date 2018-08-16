using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarGenerator : MonoBehaviour {

    public GameObject[] pool;
    public GameObject original;
	public int Max;
    public float delay;
    float flowT;
    AsyncOperation async;

    private void Awake()
    {
        flowT = 0f;
        pool = new GameObject[Max];
    }
    private void Start()
    {
        StartCoroutine(PreloadScene());
   //     async = SceneManager.LoadSceneAsync(4);
    //    async.allowSceneActivation = false;
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
        if(Input.GetMouseButtonDown(0))
        {
            async.allowSceneActivation = true;
        }
	}
    public IEnumerator PreloadScene()
    {
        yield return null;
        async = SceneManager.LoadSceneAsync(4, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while(async.progress != 0.9f)
        {

        }
        Debug.Log("Load Ready");
        yield return async;
    }

}
