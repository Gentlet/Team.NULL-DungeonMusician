using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private SpriteRenderer ren;

    public int num;
    public float startSize;
    public float multiplier;

    private void Start()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ren.size = new Vector2(ren.size.x, startSize + (AudioPeer._freqBand[num] * multiplier));
    }
}
