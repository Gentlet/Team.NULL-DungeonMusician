using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveRawImage : MonoBehaviour {
    public float speed;
    public RawImage RI;
    [SerializeField]
    float f;
    private void Start()
    {
        f = 0f;
        RI = GetComponent<RawImage>();
    }
    private void Update()
    {
            RI.uvRect = new Rect(f, 0f, 1f, 1f);
            f += speed;
    }
}
