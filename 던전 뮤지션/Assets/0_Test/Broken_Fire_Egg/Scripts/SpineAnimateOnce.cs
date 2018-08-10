using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimateOnce : MonoBehaviour {

    public SkeletonGraphic SG;
    public SkeletonAnimation SA;
    public bool IsCancas;
    public bool loof;
    public string eftName;
    public float delay; 
    private void OnEnable()
    {
        if (IsCancas)
            Invoke("SCSG", delay);
        else
            Invoke("SCSA", delay);
    }
    public void SCSG()
    {
        if (loof)
        {
            SG.AnimationState.SetAnimation(0, eftName, true);
        }
        else
            StartCoroutine(WaitDieSG());
    }
    public void SCSA()
    {
        if (loof)
        {
            SA.AnimationState.SetAnimation(0, eftName, true);

        }
        else
            StartCoroutine(WaitDieSA());
    }



    IEnumerator WaitDieSG()
    {
        if(eftName == "")
            yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0, "eft_0", false));
        else
            yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0, eftName, false));
        gameObject.SetActive(false);
    }
    IEnumerator WaitDieSA()
    {
        if (eftName == "")
            yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0, "eft_0", false));
        else
            yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0, eftName, false));
        gameObject.SetActive(false);
    }
}
