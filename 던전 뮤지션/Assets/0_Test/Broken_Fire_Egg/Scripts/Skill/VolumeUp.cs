using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeUp : ObjectStatus
{
    protected int duration;

    public int cooltime;
    public bool isactive;
    Relics relics;
    new void Awake()
    {
        base.Awake();
        fomula = true;

        duration = 5 + (level - 1);

        updateText();
    }
    public void Active()
    {
        if (isactive)
            return;
        isactive = true;
        AnimationManager.instance.AnimationInstantiate(4, new Vector2(0, 3.36f));
        relics = new Relics("-1", "VolumeUp", "", null, new RelicsEffect("VolumeUp", "Strength", 0f, Total));
        Player.Instance.Relics.Add(relics);
        EffectStorage.Instance.EffectValuesReset();

        StartCoroutine(Acting());
    }
    public IEnumerator Acting()
    {

        yield return new WaitForSeconds(duration);
        Player.Instance.Relics.Remove(relics);
        EffectStorage.Instance.EffectValuesReset();
        isactive = false;
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

    public new void Upgrade()
    {
        if (base.Upgrade())
        {
            duration++;
        }
    }
}
