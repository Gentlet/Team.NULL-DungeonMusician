using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperKeyboard : ObjectStatus
{
    //param * paramrate % 확률로 기본 노드 대신 total * playerDMG * HelperBase.total% 의 데미지를 주는 특수노드로 변환

    new void Awake()
    {
        base.Awake();
        fomula = true;
        relicRate = 1;
        basepoint = 1;
        upgraderate = 1;
        param = 1;
        parambase = 1;
        paramrate = 1;
    }
    public void AbilityActive()
    {
        if(Random.Range(0,100) < param)
        {
            EnemyManager.Instance.Enemy.AttackEnemy(Total * Player.Instance.GetStatus("Strength") * HelperBase.instance.Total);
            Debug.Log("키보드");
        }
    }
    public void UpgradeParam()
    {
        
    }
}
