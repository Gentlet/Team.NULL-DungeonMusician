using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        MoveThisObject();
    }

    private void MoveThisObject()
    {
        Vector3 dir = Vector3.zero;

        //switch (direction)
        //{
        //    case Direction.up:
        //        dir.y = speed;
        //        break;
        //    case Direction.down:
        //        dir.y = -speed;
        //        break;
        //    case Direction.right:
        //        dir.x = speed;
        //        break;
        //    case Direction.left:
        //        dir.y = -speed;
        //        break;
        //}

        transform.position += dir;
    }
}
