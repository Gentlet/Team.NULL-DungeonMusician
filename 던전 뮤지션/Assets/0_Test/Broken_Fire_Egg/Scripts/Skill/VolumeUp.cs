using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeUp : ObjectStatus
{
    protected int duration;

    public int cooltime;

    new void Awake()
    {
        base.Awake();
        fomula = true;

        duration = 5 + (level - 1);

        updateText();
    }

    public override void updateText()
    {
        textValues[0].text = level.ToString();
        textValues[1].text = upgrademoney.ToString() + " GOLD";
        textValues[2].text = "데미지 + " + upgraderate.ToString() + "%";

        string[] text = new string[3];
        int textnum = 0;

        for (int i = 0; i < explain.Length; i++)
        {
            if (explain[i] == '~')
            {
                textnum++;
                continue;
            }
            text[textnum] += explain[i];
        }

        textValues[3].text = text[0] + duration + text[1] + Total + text[2];
    }

    public override void Upgrade()
    {
        duration++;
        base.Upgrade();
    }
}
