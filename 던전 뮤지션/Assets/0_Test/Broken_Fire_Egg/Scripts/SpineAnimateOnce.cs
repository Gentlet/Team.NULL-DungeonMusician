using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimateOnce : MonoBehaviour {

    public SkeletonGraphic SG;
    private void Start()
    {
        SG = GetComponent<SkeletonGraphic>();
    }
    private void OnEnable()
    {
        StartCoroutine(WaitDie());
    }
    IEnumerator WaitDie()
    {
        yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0, "eft_0", false));
        gameObject.SetActive(false);
    }
}
