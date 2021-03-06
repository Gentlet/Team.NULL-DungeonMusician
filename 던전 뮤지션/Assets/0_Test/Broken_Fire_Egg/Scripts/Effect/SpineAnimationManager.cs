﻿using Spine.Unity;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimationManager : MonoBehaviour
{

    SkeletonGraphic SG;
    SkeletonAnimation SA;
    [SpineAnimation(dataField: "skeletonAnimation")]
    public string hit = "";
    [SpineAnimation(dataField: "skeletonAnimation")]
    public string idle = "";
    [SpineAnimation(dataField: "skeletonAnimation")]
    public string attack = "";
    [SpineAnimation(dataField: "skeletonAnimation")]
    public string effect = "";
    [SpineAnimation(dataField: "skeletonAnimation")]
    public string die = "";
    public bool IsCanvas;


    // Use this for initialization
    private void Update()
    {
    }
    private void Awake()
    {
        //TODO : 현재 장착중인 스킨 불러오기
       
    }
    void Start()
    {
       
        if (IsCanvas == true)
        {
            SG = GetComponent<SkeletonGraphic>();
        }
        else
        {
            SA = GetComponent<SkeletonAnimation>();
        }
        
    }
    public void ChangeSkin(string skinname)
    {
        Debug.Log("CS");
        if (IsCanvas == true)
        {
            SG.Skeleton.SetSkin(skinname);
            SG.AnimationState.SetAnimation(0, idle, true);
        }
        else
        {
            SA.Skeleton.SetSkin(skinname);
            SA.AnimationState.SetAnimation(0, idle, true);
        }

    }
    public void EffectAnimation()
    {

    }
    public void HittAnimation()
    {
        if (IsCanvas == true)
        {
        //    if (SG.AnimationState.GetCurrent(0).animation != SG.SkeletonData.FindAnimation(hit))
//Invoke("IdleAnimation", SG.AnimationState.SetAnimation(0, hit, false).animationEnd);
        }
        else
        {
            if (SA.state.GetCurrent(0).animation != SA.SkeletonDataAsset.GetSkeletonData(false).FindAnimation(hit))
                Invoke("IdleAnimation", SA.AnimationState.SetAnimation(0, hit, false).animationEnd);
        }
    }
    public void IdleAnimation()
    {
        if (IsCanvas == true)
            SG.AnimationState.SetAnimation(0, idle, true);
        else
            SA.AnimationState.SetAnimation(0, idle, true);
    }
    public float AttackAnimation()
    {
        if (IsCanvas == true)
        {
            float result;
            result = SG.AnimationState.SetAnimation(0, attack, false).animationEnd;
            Invoke("IdleAnimation", result);
            return result;
        }
        else
        {
            float result;
            result = SA.AnimationState.SetAnimation(0, attack, false).animationEnd;
            Invoke("IdleAnimation", result);
            return result;
        }
    }
    public void DyingAnimation(GameObject enemy)
    {
        StartCoroutine(DyingCoroutine(enemy));

    }
    public IEnumerator DyingCoroutine(GameObject enemy)
    {
        if(IsCanvas)
            yield return new WaitForSpineAnimationComplete(SG.AnimationState.SetAnimation(0, die, false));
        else
            yield return new WaitForSpineAnimationComplete(SA.AnimationState.SetAnimation(0, die, false));
        Destroy(enemy);
    }
}
