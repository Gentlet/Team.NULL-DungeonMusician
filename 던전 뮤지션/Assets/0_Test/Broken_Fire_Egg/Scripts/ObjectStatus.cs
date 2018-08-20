using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    protected bool fomula;
    public int level;
    public float basepoint;             //기본 데미지
    public float relicRate;             //유물 추가효과
    public float upgraderate;           //업그레이드 증가치

    public int firstmoney;              //맨처음 가격
    protected int upgrademoney;         //가격
    public float moneyrate;             //가격 증가치

    public float param;                 //데미지 외의 수치
    public float paramrate;             //수치 증가치
    public float parambase;             //수치 기본치

    [Multiline]
    public string explain;              //설명란

    public Text[] textValues;
    //0 레벨      1 비용       2 증가치       3 설명칸

    public void Awake()
    {
        if (moneyrate == 0)
            upgrademoney = firstmoney + (int)(firstmoney * ((level - 1) * 0.1));
        else
            upgrademoney = firstmoney + (int)(moneyrate * (level - 1));

        updateText();
    }

    public virtual void Upgrade()
    {
        if (Player.Instance.Gold >= upgrademoney)
        {
            if (moneyrate == 0)
                upgrademoney = upgrademoney + (int)(firstmoney * ((level) * 0.1));
            else
                upgrademoney = upgrademoney + (int)moneyrate;
            level++;
            //upgrademoney = (int)(upgrademoney * moneyrate);
            updateText();
            SaveInformations();
        }
    }

    public virtual void updateText()
    {
        textValues[0].text = level.ToString();
        textValues[1].text = upgrademoney.ToString() + " GOLD";
        textValues[2].text = upgraderate.ToString();

        string[] text = new string[2];
        int textnum = 0 ;

        for (int i = 0; i < explain.Length; i++)
        {
            if(explain[i] == '~')
            {
                textnum = 1;
                continue;
            }
            text[textnum] += explain[i];
        }

        textValues[3].text = text[0] + Total + text[1];
    }

    #region Properties
    public float Total
    {
        get
        {
            if (fomula == true)
            {
                return (basepoint + (upgraderate * level)) * relicRate;
            }
            else
                return basepoint * relicRate;
        }
        set
        {
            Total = value;
        }
    }
    #endregion
    public void SaveInformations()
    {
        PlayerPrefs.SetInt(GetType().Name + "level", level);
        if (!fomula)
        {

            PlayerPrefs.SetFloat(GetType().Name + "basepoint", basepoint);
            PlayerPrefs.SetFloat(GetType().Name + "paramrate", paramrate);
            PlayerPrefs.SetFloat(GetType().Name + "parambase", parambase);
            PlayerPrefs.SetFloat(GetType().Name + "upgraderate", upgraderate);
            PlayerPrefs.SetFloat(GetType().Name + "param", param);
            PlayerPrefs.SetInt(GetType().Name + "upgrademoney", upgrademoney);
        }
        PlayerPrefs.Save();
    }
    // 아래의 멤버변수, 메소드들은 상세 정보 팝업 관련 UI에 필요한 것임
    //[Multiline]
    //public string explain;
    //public GameObject basepopup;
    //protected void Awake()
    //{
    //    level = PlayerPrefs.GetInt(GetType().Name + "level", 0);
    //    basepopup = null;

    //}

}
