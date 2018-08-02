using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEvent : MonoBehaviour {
    public GameObject rebirthparticle;
    public GameObject rebirthanimation;
    public void RebirthEffect()
    {
        rebirthanimation.SetActive(true);
        rebirthparticle.SetActive(true);
    }
    


}
