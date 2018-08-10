using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public float blinkspeed;
    public bool clicktostop;

    bool isblinkenable, isincreasing, istouched;
    CanvasRenderer ren;

    void Start()
    {
        ren = GetComponent<CanvasRenderer>();
        isblinkenable = true;
    }

    void Update()
    {
        if (clicktostop)
        {
            if ((Input.GetMouseButton(0) || Input.touchCount > 0) && istouched)
                istouched = true;
        }

        if (!istouched)
        {
            if (!isblinkenable)
                return;
            else
            {
                float alpha = ren.GetColor().a;

                if (alpha <= 0)
                {
                    isincreasing = true;
                }
                else if (alpha >= 1)
                {
                    isincreasing = false;
                }

                if (isincreasing)
                {
                    alpha += blinkspeed;
                }
                else
                {
                    alpha -= blinkspeed;
                }

                ren.SetColor(new Color(ren.GetColor().r, ren.GetColor().g, ren.GetColor().b, alpha));
            }
        }
    }
}
