using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightSkill : ObjectStatus {

    public int cooltime;
    public bool isactive;

    new void Awake()
    {
        base.Awake();
        fomula = true;

        updateText();
    }

    public override void updateText()
    {
        textValues[0].text = level.ToString();
        textValues[1].text = upgrademoney.ToString() + " GOLD";
        textValues[2].text = "지속시간 + " + upgraderate.ToString() + "s";

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

    public void ParamUpgrade()
    {
        param++;
    }
    public void Active()
    {
        isactive = true;
        StartCoroutine(Acting());
    }
    public IEnumerator Acting()
    {
        yield return new WaitForSeconds(param);
        isactive = false;
    }


}
