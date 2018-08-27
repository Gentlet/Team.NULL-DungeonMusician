using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDown : MonoBehaviour
{
    private RectTransform ren;

    public int num;
    public float minSize;
    public float maxSize;
    public float multiplier;

    private void Start()
    {
        ren = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //Debug.Log(num.ToString() + " : " + AudioPeer._freqBand[num].ToString());
        float size = minSize + (AudioPeer._freqBand[num] * multiplier) > maxSize ? maxSize : minSize + (AudioPeer._freqBand[num] * multiplier);

        ren.sizeDelta = new Vector2(ren.sizeDelta.x, size);
    }
}
