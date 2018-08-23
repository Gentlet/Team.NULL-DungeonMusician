﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busking : ObjectStatus {
    //base 추가%
    public int cooltime;
    public bool isActive;
    Relics relics;
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
        textValues[2].text = "보상 + " + upgraderate.ToString() + "%";

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

    public void Start()
    {
        isActive = false;
    }

    public void Active()
    {
        isActive = true;

        relics = new Relics("-1", "Busking", "", null, new RelicsEffect("Busking", "Extragoldrate", 0f, 100f));
        Player.Instance.Relics.Add(relics);
        EffectStorage.Instance.EffectValuesReset();

    }
    public void Off()
    {

    }
}
