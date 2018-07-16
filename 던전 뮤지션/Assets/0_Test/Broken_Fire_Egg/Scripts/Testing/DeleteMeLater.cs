using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class DeleteMeLater : MonoBehaviour {

    public SkeletonGraphic SG;

    private void OnEnable()
    {
        StartCoroutine(WaitDie());
    }
    IEnumerator WaitDie()
    {
        yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0,"eft_0",false));
        gameObject.SetActive(false);
    }
}
