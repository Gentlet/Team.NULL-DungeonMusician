using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjectAnimation : MonoBehaviour {
    public Animator[] animators;
    public string triggerName;

    private void Start()
    {
        TriggerAll();
    }
    public void TriggerAll()
    {
       foreach(Animator anitor in animators)
        {
            anitor.SetTrigger(triggerName);
        }
    }

    public void TriggerOne(int n)
    {
        animators[n].SetTrigger(triggerName);
    }

    public void SetDefaultAll()
    {
        foreach (Animator anitor in animators)
        {
            anitor.SetTrigger("Default");
        }
    }
}
