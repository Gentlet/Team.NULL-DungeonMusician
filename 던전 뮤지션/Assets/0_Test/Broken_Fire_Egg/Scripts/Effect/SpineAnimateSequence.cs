using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimateSequence : MonoBehaviour {
    public SkeletonGraphic SG;
    public SkeletonAnimation SA;
    public bool IsCancas;
    [SpineAnimation(dataField: "skeletonAnimation")]
    public string[] sequence;
    public bool[] loof;
    [SerializeField]
    int curr;
    bool animating;
    private void Start()
    {
        Play();
        animating = false;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PauseEntry();
        }
    }
    void Play()
    {
        if (!IsCancas)
            StartCoroutine(SACoroutine());
        else
            StartCoroutine(SGCoroutine());
    }
    public void PauseEntry()
    {
        if (loof[curr])
        {
            if (IsCancas)
                SG.AnimationState.ClearTrack(0);
            else
                SA.AnimationState.ClearTrack(0);
        }
        else
        {
            if (IsCancas)
                SG.AnimationState.SetEmptyAnimation(0,0f);
            else
                SA.AnimationState.ClearTrack(0);
        }
    }
    public void clear()
    {
        SG.AnimationState.ClearTracks();
    }
    public IEnumerator SGCoroutine()
    {
        while (curr < sequence.Length)
        {
            if (loof[curr])
            {
                animating = true;
                yield return new WaitForSpineTrackEntryEnd(SG.AnimationState.SetAnimation(0, sequence[curr], true));
            }
            else
            {
                animating = true;
                yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0, sequence[curr], false));
            }
            curr++;
        }
        yield return null;
    }
    public IEnumerator SACoroutine()
    {
        while (curr <= sequence.Length)
        {
            yield return new WaitForSpineAnimationComplete(SA.AnimationState.SetAnimation(0, sequence[curr], false));
            curr++;
        }
        yield return null;
    }
}
