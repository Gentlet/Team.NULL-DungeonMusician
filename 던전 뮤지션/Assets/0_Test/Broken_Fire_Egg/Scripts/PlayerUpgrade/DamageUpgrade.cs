using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : ObjectStatus
{
    new void Awake()
    {
        base.Awake();
        fomula = true;
        basepoint = 1;
        upgraderate = 1;
        param = 1;
        paramrate = 1;
    }
    new void Upgrade()
    {
        if (fomula == true)
        {
            base.Upgrade();
            Player.Instance.Criticalrate = Total;
        }
        else
        {
            level++;
            basepoint *= upgraderate;
            upgrademoney = (int)(upgrademoney * moneyrate);
            SaveInformations();
        }
    }
}
