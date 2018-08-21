using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    public GameObject[] instantiates;
    public GameObject[] OnOffs;

    public void AnimationInstantiate(int n,Vector2 position_)
    {
        Instantiate(instantiates[n], position_, Quaternion.identity);
    }
    public void AnimationOn(int n, float timer = 0f)
    {
        OnOffs[n].SetActive(true);
        if(timer != 0f)
            StartCoroutine(AnimationOffC(n, timer));
    }
    public void AnimationOff(int n)
    {
        OnOffs[n].SetActive(false);
    }
        IEnumerator AnimationOffC(int n,float timer = 0f)
    {
        yield return new WaitForSeconds(timer);
        OnOffs[n].SetActive(false);
    }



}
