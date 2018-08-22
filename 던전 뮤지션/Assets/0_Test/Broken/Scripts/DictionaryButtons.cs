using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryButtons : MonoBehaviour
{
    private Button button;

    private GameObject blinder;

    [System.NonSerialized]
    public Relics relic;
    public Image relicimage;

    public GameObject cover;
    public Image explainImage;
    public Text name;
    public Text effect;
    public Text explain;

    public void Init(Relics _relic, Sprite _image, GameObject _cover, Image _explainImage, Text _name, Text _effect, Text _explain)
    {
        button = GetComponent<Button>();
        relicimage = transform.GetChild(0).GetComponent<Image>();
        blinder = transform.GetChild(1).gameObject;

        relic = _relic;
        relicimage.sprite = _image;
        cover = _cover;
        explainImage = _explainImage;
        name = _name;
        effect = _effect;
        explain = _explain;
    }

    public void BlindOn()
    {
        blinder.SetActive(true);
        button.interactable = false;
    }
    public void BlindOff()
    {
        blinder.SetActive(false);
        button.interactable = true;
    }

    public void ShowInformations()
    {
        explainImage = relicimage;
        name.text = relic.name;
        //effect.text = relic.relicseffect;
        explain.text = relic.explain;
        cover.SetActive(true);
    }

    public void CloseInformations()
    {
        cover.SetActive(false);
    }
}
