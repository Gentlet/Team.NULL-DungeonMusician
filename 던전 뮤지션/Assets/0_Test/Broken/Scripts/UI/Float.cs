using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public bool updown;
    public float distance;
    public float speed;

    private RectTransform trans;
    private Vector3[] vec = new Vector3[2];
    private bool state, timer;

    private void Start()
    {
        state = true;
        trans = GetComponent<RectTransform>();

        if (updown)
        {
            vec[0] = trans.position + new Vector3(0f, distance);
            vec[1] = trans.position + new Vector3(0f, -distance);
        }
        else
        {
            vec[0] = trans.position + new Vector3(distance, 0f);
            vec[1] = trans.position + new Vector3(-distance, 0f);
        }
    }

    private void Update()
    {
        if (!timer)
        {
            if (state)
                floatUp();
            else
                floatDown();
        }

    }

    void floatUp()
    {
        trans.position = Vector3.Lerp(trans.position, vec[0], speed * Time.deltaTime);
        if (Vector3.Distance(trans.position, vec[0]) <= 0.05f)
        {
            timer = true;
            Invoke("Timer", 0.5f);
        }
    }
    void floatDown()
    {
        trans.position = Vector3.Lerp(trans.position, vec[1], speed * Time.deltaTime);
        if (Vector3.Distance(trans.position, vec[1]) <= 0.05f)
        {
            timer = true;
            Invoke("Timer", 0.5f);
        }
    }

    void Timer()
    {
        state = !state;
        timer = false;
    }
}
