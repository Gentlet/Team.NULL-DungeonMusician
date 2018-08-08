using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimateOnce : MonoBehaviour {

    public SkeletonGraphic SG;
    public SkeletonAnimation SA;
    public bool IsCancas;
    public string eftName;
    private void OnEnable()
    {
        if (IsCancas)
            StartCoroutine(WaitDieSG());
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
