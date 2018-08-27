using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDown : MonoBehaviour
{
    private RectTransform ren;

    public int num;
    public float startSize;
    public float maxSize;
    public float multiplier;

    private void Start()
    {
        ren = GetComponent<RectTransform>();
    }

    private void Update()
    {
        float size = startSize + (AudioPeer._freqBand[num] * multiplier) > maxSize ? startSize + (AudioPeer._freqBand[num] * multiplier) : maxSize;

        ren.sizeDelta = new Vector2(ren.sizeDelta.x, startSize + (AudioPeer._freqBand[num] * multiplier));
    }
}
