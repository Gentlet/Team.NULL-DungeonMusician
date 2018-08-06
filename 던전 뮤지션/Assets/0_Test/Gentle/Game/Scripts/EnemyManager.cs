using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonGameObject<EnemyManager> {
    [Header("Enemy Objects")]
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject gameui;
    [SerializeField]
    private Enemy[] enemyprefabs;
    [SerializeField]
    private Enemy enemy;

    private int killcount = 0;


    public void CreateEnemy(int num = -1)
    {
        enemy = Instantiate(enemyprefabs[(num == -1 ? killcount : num)], gameui.transform);
    }

    public void KillEnemy(int gold)
    {
        if (enemy != null)
        {
            Destroy(enemy.gameObject);

            killcount += 1;
            Player.Instance.Gold += (int)(gold * Player.Instance.GetStatus("Extragoldrate"));

            if(0 < enemyprefabs.Length)
            {
                CreateEnemy(Random.Range(0, enemyprefabs.Length));
            }
        }
    }

    #region Properties
    public Enemy Enemy
    {
        get
        {
            return enemy;
        }
    }
    #endregion
}
