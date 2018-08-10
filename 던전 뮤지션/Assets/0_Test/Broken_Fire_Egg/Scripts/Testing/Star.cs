using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    public RectTransform RT;
    public float speedMin;
    public float speedMax;
    public float sizeMin;
    public float sizeMax;

    bool shrink;
    float cursize;
    float speed;
    float targetSize;
    private void Start()
    {
        shrink = false;
        cursize = 0f;
        speed = Random.Range(speedMin, speedMax);
        targetSize = Random.Range(sizeMin, sizeMax);
     //   RT.position.Set(Random.Range(-540f, 540f), Random.Range(-180f, 180f),0f);
    }
    private void Update()
    {
        if (shrink)
            cursize -= speed;
        else
            cursize += speed;



        RT.sizeDelta = new Vector2(cursize, cursize);
        if (cursize < 0f)
            Destroy(gameObject);
        if (cursize > targetSize)
            shrink = true;

    }
}
