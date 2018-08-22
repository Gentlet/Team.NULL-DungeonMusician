using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //ren.size = new Vector2(ren.size.x, startSize + (AudioPeer._freqBand[num] * multiplier));

        float size = minSize + (AudioPeer._freqBand[num] * multiplier) > maxSize ? maxSize : minSize + (AudioPeer._freqBand[num] * multiplier);

        ren.sizeDelta = new Vector2(ren.sizeDelta.x, size);
    }
}
