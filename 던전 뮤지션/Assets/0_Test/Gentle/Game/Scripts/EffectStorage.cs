using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EffectValue
{
    public string name;
    public List<RelicsEffect> relicseffects;

    public EffectValue()
    {
        name = string.Empty;
        relicseffects = new List<RelicsEffect>();
    }

    public EffectValue(RelicsEffect relicseffect)
    {
        name = relicseffect.name;
        relicseffects = new List<RelicsEffect>();

        relicseffects.Add(relicseffect);
    }

    public RelicsEffect FindRelicsEffect(string relicsname)
    {
        for (int i = 0; i < relicseffects.Count; i++)
        {
            if (relicseffects[i].relicsname == relicsname)
                return relicseffects[i];
        }

        return null;
    }

    #region Properties
    public float ResultStatus
    {
        get
        {
            float result = 0f;
            float value = 0f;
            float percent = 0f;

            result = (float)Player.Instance.GetType().GetProperty(name).GetValue(Player.Instance, null);

            for (int i = 0; i < relicseffects.Count; i++)
            {
                value += relicseffects[i].value;
                percent += relicseffects[i].percent;
            }

            result += value;
            result *= 1 + (percent / 100f);

            return result;
        }
    }
    #endregion
}

public class EffectStorage : SingletonGameObject<EffectStorage> {

    private Player player;

    [SerializeField]
    private List<EffectValue> effects;

    private void Awake()
    {
        player = Player.Instance;

        effects = new List<EffectValue>();
    }

    public void EffectValuesReset()
    {
        effects.Clear();

        for (int i = 0; i < player.Relics.Count; i++)
        {
            for (int j = 0; j < effects.Count; j++)
            {
                if (player.Relics[i].relicseffect.name == effects[j].name)
                {
                    RelicsEffect temp = effects[j].FindRelicsEffect(player.Relics[i].name);

                    //if (temp != null)
                    //{
                    //    temp.value += player.Relics[i].relicseffect.value;
                    //    temp.percent += player.Relics[i].relicseffect.percent;
                    //}
                    //else
                    //{
                    //    temp = new RelicsEffect(player.Relics[i].relicseffect.relicsname, player.Relics[i].relicseffect.name, player.Relics[i].relicseffect.value, player.Relics[i].relicseffect.percent);
                    //    effects[j].relicseffects.Add(temp);
                    //}

                    if (temp == null)
                        effects[j].relicseffects.Add(player.Relics[i].relicseffect);

                    break;
                }

                if (j == effects.Count - 1)
                    effects.Add(new EffectValue(player.Relics[i].relicseffect));
            }

            if (0 == effects.Count)
                effects.Add(new EffectValue(player.Relics[i].relicseffect));
        }
    }

    public float GetStatus(string name)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            if (effects[i].name == name)
                return effects[i].ResultStatus;
        }

        return (float)Player.Instance.GetType().GetProperty(name).GetValue(Player.Instance, null);
    }
}
