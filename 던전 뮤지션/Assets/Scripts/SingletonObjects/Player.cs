using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempSkill
{

}

public class TempHelper
{

}

public class Player : SingletonGameObject<Player> {

    private float maxhealth;
    private float health;

    private int gold;
    private int revivepoint;

    private float strength = 1f;
    private float criticalrate = 50f;
    private float criticaldamage = 150f;
    private float healthdrainrate;

    private float extragoldrate;

    private TempSkill[] skills;
    
    [SerializeField]
    private List<Relics> relics;
    private List<TempHelper> helpers;
    private List<Bundle> bundles;

    public Text goldtext;
    public Text revivepointtext;

    private void Awake()
    {
        skills = new TempSkill[2];

        relics = new List<Relics>();
        helpers = new List<TempHelper>();
        bundles = new List<Bundle>();

        Gold = 500000;
        Revivepoint = 0;

        //Invoke("AAAA", 1f);
    }

    //public void AAAA()
    //{
    //    Debug.Log("aaa");
    //    relics.Add(GameManager.Instance.ReadDatas.relicses[0]);
    //EffectStorage.Instance.EffectValuesReset();
    //}

    public float GetStatus(string name)
    {
        //if (name == "Criticaldamage")
        //    Debug.Log("크리크리왕크리");

        return EffectStorage.Instance.GetStatus(name);
    }

    public void Revive()
    {

        //AnimationManager.instance.AnimationInstantiate(6, Vector2.zero);
        AnimationManager.instance.AnimationOn(4,2f);
        ParticleManager.instance.PlayParticle(4, Vector2.zero);
        Invoke("ActuallyRevive",1.5f);
    }
    public void ActuallyRevive()
    {
        
    }

    #region Properties
    public float MaxHealth
    {
        get
        {
            return maxhealth;
        }
    }

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;

            if (health > maxhealth)
                health = maxhealth;
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldtext.text = gold.ToString();
        }
    }

    public int Revivepoint
    {
        get
        {
            return revivepoint;
        }
        set
        {
            revivepoint = value;
            revivepointtext.text = revivepoint.ToString();
        }
    }

    public float Strength
    {
        get
        {
            return strength;
        }
        set
        {
            strength = value;
        }
    }

    public float Criticalrate
    {
        get
        {
            return criticalrate;
        }
        set
        {
            criticalrate = value;
        }
    }

    public float Criticaldamage
    {
        get
        {
            return criticaldamage;
        }
        set
        {
            criticaldamage = value;
        }
    }

    public float Healthdrainrate
    {
        get
        {
            return healthdrainrate;
        }
        set
        {
            healthdrainrate = value;
        }
    }

    public float Extragoldrate
    {
        get
        {
            return extragoldrate;
        }
        set
        {
            extragoldrate = value;
        }
    }

    public TempSkill[] Skills
    {
        get
        {
            return skills;
        }
    }

    public List<Relics> Relics
    {
        get
        {
            return relics;
        }
    }

    public List<TempHelper> Helpers
    {
        get
        {
            return helpers;
        }
    }

    public List<Bundle> Bundles
    {
        get
        {
            return bundles;
        }
    }
    #endregion
}
