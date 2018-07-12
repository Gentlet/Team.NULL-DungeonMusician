using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : ObjectStatus
{

    //param : 시간
    //basepoint 데미지%
    float dottime;

    public void Active()
    {
        StartCoroutine(vibreating());
    }
    IEnumerator vibreating()
    {

        WaitForSeconds WS = new WaitForSeconds(dottime);
        int times = 0;
        while(times * dottime <= param)
        {
            times++;
            yield return WS;
        }

    }
}
