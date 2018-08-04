using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperGuitar : ObjectStatus
{

    //플레이어가 기본 노드를 터치할 때마다 total * playerDMG * HelperBase의 total%의 데미지로 추가 공격

    new void Awake()
    {
        base.Awake();
        fomula = true;
        basepoint = 1;
        upgraderate = 1;
        parambase = 1;
        paramrate = 1;
    }
    public void AbilityActive()
    {

        EnemyManager.Instance.Enemy.AttackEnemy(Total * Player.Instance.GetStatus("Strength") * HelperBase.instance.Total);
    }
}
