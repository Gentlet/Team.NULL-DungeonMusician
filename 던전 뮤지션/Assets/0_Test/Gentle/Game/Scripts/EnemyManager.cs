using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Space]
    [Header("Boss")]
    public Sprite[] bgsprites;
    public Image bg;


    public void CreateEnemy(int num = -1)
    {
        enemy = Instantiate(enemyprefabs[(num == -1 ? killcount % enemyprefabs.Length : num)], gameui.transform);

        if(killcount % enemyprefabs.Length == enemyprefabs.Length - 1)
            bg.sprite = bgsprites[1];
        else
            bg.sprite = bgsprites[0];
    }

    public void KillEnemy(int gold)
    {
        if (enemy != null)
        {
            Destroy(enemy.gameObject);

            killcount += 1;
            Player.Instance.Gold += (int)(gold * Player.Instance.GetStatus("Extragoldrate"));
            Busking.instance.Off();

            enemy = null;

            if (killcount % enemyprefabs.Length != enemyprefabs.Length - 1 && killcount % enemyprefabs.Length != 0)
                CreateEnemy();
            else
                GameManager.Instance.TurnOffGame();

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
