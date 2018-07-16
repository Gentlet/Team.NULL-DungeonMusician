using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private float criticalrate = 50;
    private float criticaldamage = 50;
    private float healthdrainrate;

    private float extragoldrate;

    private TempSkill[] skills;

    private List<Relics> relics;
    private List<TempHelper> helpers;
    private List<Bundle> bundles;

    protected override void Init()
    {
        skills = new TempSkill[2];

        relics = new List<Relics>();
        helpers = new List<TempHelper>();
        bundles = new List<Bundle>();
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
        }
    }

    public float Revivepoint
    {
        get
        {
            return revivepoint;
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
            Criticalrate = value;
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
            Criticaldamage = value;
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
    }


    #endregion
}
