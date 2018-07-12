using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    protected bool fomula;
    public int level;
    public float basepoint; //데미지를 표현할때 씀
    public float paramrate;
    public float parambase;
    public float relicRate;
    public float upgraderate;
    public int upgrademoney;
    public float moneyrate;
    public float param; //데미지 말고 다른 수치를 표현 할떄 씀



    protected void Upgrade()
    {
        level++;
        upgrademoney = (int)(level * upgraderate);
        //upgrademoney = (int)(upgrademoney * moneyrate);
        SaveInformations();
    }

    #region Properties
    public float Total
    {
        get
        {
            if (fomula == true)
                return (basepoint + (upgraderate * level)) * relicRate;
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
    public string explain;
    public GameObject basepopup;
    protected void Awake()
    {
        level = PlayerPrefs.GetInt(GetType().Name + "level",0);
        basepopup = null;
        
    }

}
