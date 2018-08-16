using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : ObjectStatus
{

    //param : 시간
    //basepoint 데미지%
    float dottime;

    new void Awake()
    {
        updateText();
    }

    public override void updateText()
    {
        textValues[0].text = level.ToString();
        textValues[1].text = upgrademoney.ToString() + " GOLD";
        textValues[2].text = "데미지 + " + upgraderate.ToString() + "%";

        string[] text = new string[2];
        int textnum = 0;

        for (int i = 0; i < explain.Length; i++)
        {
            if (explain[i] == '~')
            {
                textnum = 1;
                continue;
            }
            text[textnum] += explain[i];
        }

        textValues[3].text = text[0] + Total + text[1];
    }

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
