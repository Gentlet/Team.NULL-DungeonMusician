using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverEffect : MonoBehaviour {

    public GameObject feverPref;

	// Use this for initialization

    public void Fever()
    {
        Instantiate(feverPref);
        
    }
}
