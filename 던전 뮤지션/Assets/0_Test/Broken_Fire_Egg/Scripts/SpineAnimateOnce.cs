using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimateOnce : MonoBehaviour {

    public SkeletonGraphic SG;
    public SkeletonAnimation SA;
    public bool IsCancas;
    private void OnEnable()
    {
        
        if (IsCancas)
            StartCoroutine(WaitDieSG());
        else
            StartCoroutine(WaitDieSA());
        
    }
    IEnumerator WaitDieSG()
    {
        yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0, "eft_0", false));
        gameObject.SetActive(false);
    }
    IEnumerator WaitDieSA()
    {
        yield return new WaitForSpineAnimationComplete(SA.AnimationState.SetAnimation(0, "eft_0", false));
        gameObject.SetActive(false);
    }
}
