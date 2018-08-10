using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Range(0, 1)]
    public int direction;
    public float speed;

    private void Update()
    {
        if (direction == 1)
            transform.Rotate(0f, 0f, speed);
        else
            transform.Rotate(0f, 0f, -speed);
    }
}
