using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
public class TestingFuncs : MonoBehaviour {
    public InputField IF;
    public SkeletonAnimation SA;
    SkeletonDataAsset SkeletonDataAsset;
    public List<SkeletonDataAsset> skeletonDataAssets = new List<SkeletonDataAsset>();

    void Start()
    {
        foreach(SkeletonDataAsset sda in skeletonDataAssets)
        {
            sda.GetSkeletonData(false);
        }
    }

   public  void LoadSkeletonAsset(int num)
    {
        Debug.Log("a");
        var spineAnimation = skeletonDataAssets[num].GetSkeletonData(false).FindAnimation("idle_0");
        //SA.SkeletonDataAsset.InitializeWithData();
        SA.Initialize(false);
    }

}
