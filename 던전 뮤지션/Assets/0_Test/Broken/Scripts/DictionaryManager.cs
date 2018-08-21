using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryManager : MonoBehaviour
{
    private List<GameObject> relicList;



    public GameObject relicparent;
    public GameObject monsterparent;
    public GameObject objOrigin;

    public GameObject cover;
    public Image explainImage;
    public Text name;
    public Text effect;
    public Text explain;



    private void Start()
    {
        relicList = new List<GameObject>();


        CreateRelics();
        UpdateRelicBlind();
    }

    private void CreateRelics()
    {
        for (int i = 0; i < GameManager.Instance.ReadDatas.relicses.Count; i++)
        {
            GameObject obj = Instantiate(objOrigin, relicparent.transform);
            DictionaryButtons button = obj.GetComponent<DictionaryButtons>();

            Relics relics = GameManager.Instance.ReadDatas.relicses[i];

            button.Init(relics, relics.sprite, cover, explainImage, name, effect, explain);
            obj.gameObject.name = i.ToString();

            relicList.Add(obj);
        }
    }

    private void UpdateRelicBlind()
    {
        for (int i = 0; i < Player.Instance.Relics.Count; i++)
        {
            for (int j = 0; j < GameManager.Instance.ReadDatas.relicses.Count; j++)
            {
                Relics relic = GameManager.Instance.ReadDatas.relicses[j];

                if (Player.Instance.Relics[i].name == relic.name)
                {
                    //relic.GetComponent<DictionaryButtons>().relic = Player.Instance.Relics[i];
                    relicList[j].GetComponent<DictionaryButtons>().BlindOff();
                    break;
                }
            }
        }
    }


}
