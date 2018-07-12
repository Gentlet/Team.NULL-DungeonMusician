using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : ObjectStatus
{

    public void Active()
    {
        EnemyManager.Instance.Enemy.AttackEnemy(Player.Instance.Strength * basepoint);
    }
}
