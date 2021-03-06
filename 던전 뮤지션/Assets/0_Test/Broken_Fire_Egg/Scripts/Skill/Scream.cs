﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : ObjectStatus
{
    public int cooltime;

    new void Awake()
    {
        base.Awake();
        fomula = true;

        updateText();
    }
    public new void Upgrade()
    {
        base.Upgrade();
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
        AnimationManager.instance.AnimationInstantiate(1, new Vector2(0, 3.36f));
        EnemyManager.Instance.Enemy.AttackEnemy(Player.Instance.GetStatus("Strength") * basepoint);
    }
}
