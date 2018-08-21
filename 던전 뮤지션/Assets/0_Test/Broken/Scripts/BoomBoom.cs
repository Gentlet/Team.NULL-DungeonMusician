using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoom : MonoBehaviour
{
    public float multiplier;
    public float minScale;
    public float maxScale;

    private void Update()
    {
        float scale = maxScale < minScale + (AudioPeer._freqBand[1] * multiplier) ? maxScale : minScale + (AudioPeer._freqBand[3] * multiplier);

        transform.localScale = new Vector2(scale, scale);
    }
}
