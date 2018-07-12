using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperDrum : ObjectStatus
{
    //플레이어가 param콤보 할 때마다 total * playerDMG * HelperBase.total%의 데미지로 추가 공격

    new void Awake()
    {
        base.Awake();
        fomula = true;

        basepoint = 1;
        upgraderate = 1;
        parambase = 1;
        paramrate = 1;
    }
    public void AbilityActive(int combo)
    {
        if (combo % param == 0)
        {
            EnemyManager.Instance.Enemy.AttackEnemy(Total * Player.Instance.Strength * HelperBase.instance.Total);
        }
    }
}
