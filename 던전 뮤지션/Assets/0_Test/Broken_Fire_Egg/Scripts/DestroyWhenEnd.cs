using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenEnd : StateMachineBehaviour {
    public bool insteadOff;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (insteadOff)
            animator.gameObject.SetActive(false);
        else
            Destroy(animator.gameObject);
    }

}
