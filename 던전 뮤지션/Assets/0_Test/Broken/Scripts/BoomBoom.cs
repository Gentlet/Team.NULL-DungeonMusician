﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoom : MonoBehaviour
{
    private RectTransform rect;

    public float multiplier;
    public float minScale;
    public float maxScale;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        float scale = maxScale < minScale + (AudioPeer._freqBand[1] * multiplier) ? maxScale : minScale + (AudioPeer._freqBand[3] * multiplier);

        rect.sizeDelta = new Vector2(scale, scale);
    }
}
