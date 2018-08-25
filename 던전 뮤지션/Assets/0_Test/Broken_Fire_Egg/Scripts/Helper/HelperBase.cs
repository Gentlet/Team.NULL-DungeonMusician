using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperBase : ObjectStatus
{
    //다른 조력자들의 데미지를 total%만큼 올려줌
    //다른 조력자들이 버프를 받기 위해 이 클래스를 참조한다
    //그래서 초기화 말곤 아무것도 할게 없어 보인다.
    public static HelperBase instance;
    public GameObject SpineObject;
    new void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        base.Awake();

        fomula = true;
        //basepoint = 1;
        //upgraderate = 1;
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

    private void Update()
    {

            if (EnemyManager.Instance.Enemy.isActiveAndEnabled)
                if (Random.Range(1, 300) == 1)
                    AbilityActive();

    }
    public void AbilityActive()
    {
        //사실상 이펙트 효과
        SpineObject.SetActive(true);
    }
}
