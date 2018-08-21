using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryManager : MonoBehaviour
{
    public Button[] relicbtns;
    public Button[] monsterbtns;

    private Relics relic;

    private void Start()
    {
        Player.Instance.Relics.Add(new Relics("0", "실로폰", "띠리링띵띵", null, null));
        Player.Instance.Relics.Add(new Relics("3", "탬탬버린", "홋치", null, null));
        UpdateRelicBlind();
    }

    private void UpdateRelicBlind()
    {
        for (int i = 0; i < Player.Instance.Relics.Count; i++)
        {
            for (int j = 0; j < relicbtns.Length; j++)
            {
                if (Player.Instance.Relics[i].relicsnum.ToString() == relicbtns[j].name)
                {
                    relicbtns[j].GetComponent<DictionaryButtons>().relic = Player.Instance.Relics[i];
                    relicbtns[j].GetComponent<DictionaryButtons>().BlindOff();
                    break;
                }
            }
        }
    }


}
