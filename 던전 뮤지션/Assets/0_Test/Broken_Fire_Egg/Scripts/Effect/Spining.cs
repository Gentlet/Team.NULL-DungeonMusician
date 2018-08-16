using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spining : MonoBehaviour {
    public RectTransform rect;
    public bool updown;
	// Update is called once per frame
	void Update () {
        if(!updown)
            rect.Rotate(new Vector3(0, 0, 1));
        else
        {

        }

	}
}
