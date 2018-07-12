using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSim : SingletonGameObject<TouchSim>
{
    public int state;
    public TouchPhase phase;

    private Vector2 pos;

    void Update()
    {
        if (state == 4)
        {
            state = 0;
            transform.position = Vector2.right * 10;
            phase = TouchPhase.Canceled;
        }

        if (Input.GetMouseButtonDown(0))
        {
            state = 1;
            phase = TouchPhase.Began;
        }
        else if (Input.GetMouseButton(0))
        {
            if (state != 3)
                state = 2;
            phase = TouchPhase.Stationary;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            state = 4;
            phase = TouchPhase.Ended;
        }

        if (state != 0 && state != 4)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (state == 1)
                pos = transform.position;
            else
            {
                float distance = Vector2.Distance(pos, transform.position);

                if (distance >= 0.3f)
                {
                    state = 3;
                    phase = TouchPhase.Moved;
                }
            }
        }
    }
}
