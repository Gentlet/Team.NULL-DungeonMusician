using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    public float speed;
    public float widthSize;
    public RectTransform[] childs;

    private Vector3 moveForce;

    private void Start()
    {
        moveForce = new Vector3(speed, 0f, 0f);
    }

    private void Update()
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].position += (moveForce * Time.deltaTime);

            if (childs[i].transform.localPosition.x > 1080f)
            {
                if (i == 0)
                    childs[i].localPosition = childs[childs.Length - 1].localPosition - new Vector3(widthSize, 0f);
                else
                    childs[i].localPosition = childs[i - 1].localPosition - new Vector3(widthSize, 0f);
            }
        }
    }
}
