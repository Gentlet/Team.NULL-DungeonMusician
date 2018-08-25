using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightSkill : ObjectStatus {

    public int cooltime;
    public bool isactive;


    Relics relics;
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

        if (isactive)
            return;
        isactive = true;
        ParticleManager.instance.PlayParticle(1, new Vector2(0, 3.36f));
        relics = new Relics("-1", "tmpSpotLight", "", null, new RelicsEffect("tmpSpotlight", "Criticalrate", 0f, 100f));
        Player.Instance.Relics.Add(relics);
        EffectStorage.Instance.EffectValuesReset();

        StartCoroutine(Acting());
    }
    public IEnumerator Acting()
    {

        yield return new WaitForSeconds(param);
        Player.Instance.Relics.Remove(relics);
        EffectStorage.Instance.EffectValuesReset();
        isactive = false;
    }


}
