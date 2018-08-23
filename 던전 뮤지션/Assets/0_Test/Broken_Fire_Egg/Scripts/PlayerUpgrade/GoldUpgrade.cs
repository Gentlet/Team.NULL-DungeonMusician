﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldUpgrade : ObjectStatus
{
    new void Awake()
    {
        base.Awake();
        fomula = true;
        //basepoint = 1;
        //upgraderate = 1;
        //param = 1;
        //paramrate = 1;

        updateText();
    }

    public override void updateText()
    {
        textValues[0].text = level.ToString();
        textValues[1].text = upgrademoney.ToString() + " GOLD";
        textValues[2].text = "수급량 + " + upgraderate.ToString() + "%";

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

    new void Upgrade()
    {
        if (base.Upgrade())
        {
            Player.Instance.Extragoldrate = Total;
        }
    }
}
