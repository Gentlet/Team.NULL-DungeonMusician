using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperKeyboard : ObjectStatus
{
    //param * paramrate % 확률로 기본 노드 대신 total * playerDMG * HelperBase.total% 의 데미지를 주는 특수노드로 변환
    public static HelperKeyboard instance;
    public GameObject SpineObject;
    new void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        base.Awake();
        fomula = true;
        relicRate = 1;
        //basepoint = 1;
        //upgraderate = 1;
        //param = 1;
        //parambase = 1;
        //paramrate = 1;

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

        string[] text = new string[3];
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

    public void AbilityActive()
    {
        if(Random.Range(0,100) < param)
        {
            EnemyManager.Instance.Enemy.AttackEnemy(Total * Player.Instance.GetStatus("Strength") * HelperBase.instance.Total);
            SpineObject.SetActive(true);
        }
    }
    public void UpgradeParam()
    {
        
    }
}
