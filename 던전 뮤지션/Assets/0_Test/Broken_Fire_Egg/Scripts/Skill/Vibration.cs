using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : ObjectStatus
{

    //param : 시간
    //basepoint 데미지%
    public int cooltime;
    float dottime;
    public new void Upgrade()
    {
        base.Upgrade();
    }
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
        AnimationManager.instance.AnimationInstantiate(3, new Vector2(0, 2.55f));
        StartCoroutine(vibreating());
    }
    WaitForSeconds time5 = new WaitForSeconds(0.5f);
    IEnumerator vibreating()
    {
        int time = 0;
        while(time <20)
        {
            EnemyManager.Instance.Enemy.AttackEnemy(Total * Player.Instance.GetStatus("Strength"));
            yield return time5;
            time++;
        }
        
    }
}
