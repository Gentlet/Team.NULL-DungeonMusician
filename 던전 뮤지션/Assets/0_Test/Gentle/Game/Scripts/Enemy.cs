using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private SpineAnimationManager spine;

    [SerializeField]
    private string info;
    [SerializeField]
    private float maxhp;
    [SerializeField]
    private int gold;

    private Text ui_info;
    private Image ui_hp;

    private float hp;

    public Vector2 test;
    public float time;

    private void Awake()
    {
        hp = maxhp;

        ui_info = transform.Find("EnemyInfo").GetComponent<Text>();
        ui_info.text = info;

        ui_hp = transform.Find("EnemyHP").Find("HPFill").GetComponent<Image>();
        ui_hp.fillAmount = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            StartCoroutine(Skill3());
    }

    public void AttackEnemy(float damage)
    {
        hp -= damage;

        ui_hp.fillAmount -= damage / maxhp;

        spine.HittAnimation();

        if (hp <= 0)
            EnemyManager.Instance.KillEnemy(gold);
    }

    public IEnumerator Skill1()
    {
        spine.AttackAnimation();

        yield return new WaitForSeconds(time);

        for (int i = 0; i < Random.Range(4, 7); i++)
        {
            GameManager.Instance.CreateNote(GameManager.Instance.Lines[Random.Range(0, 4)], NoteType.NORMAL);

            yield return new WaitForSeconds(Random.Range(test.x, test.y));
        }
    }

    public IEnumerator Skill2()
    {
        spine.AttackAnimation();

        yield return new WaitForSeconds(time);

        GameManager.Instance.IsReverse = true;

        yield return new WaitForSeconds(1f);

        GameManager.Instance.IsReverse = false;
    }

    public IEnumerator Skill3()
    {
        //사용하지 마시오

        spine.AttackAnimation();

        yield return new WaitForSeconds(time);

        int count = Random.Range(3, 5);

        while(0 < count)
        {
            if(GameManager.Instance.Notes[Random.Range(0, GameManager.Instance.Notes.Count)].ChanageLine() == false)
            {
                for (int i = 0; i < GameManager.Instance.Notes.Count; i++)
                {
                    if (GameManager.Instance.Notes[i].IsChanged == false)
                        continue;
                }

                break;
            }

            count -= 1;
        }
    }

    #region Properties
    #endregion
}
