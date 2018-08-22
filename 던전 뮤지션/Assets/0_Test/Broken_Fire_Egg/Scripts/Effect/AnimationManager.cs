using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {


    public static AnimationManager instance;
    public Animator animator;
    private void Start()
    {
        if(instance == null)
            instance = this;
    }

    public GameObject[] instantiates; //단일 애니메이션 (자동으로 꺼짐), (좌표 설정)
    public GameObject[] OnOffs;       //껏다 켯다 해야 하는 에니메이션 ()

    public void AnimationInstantiate(int n,Vector2 position_)
    {
        Instantiate(instantiates[n], position_, Quaternion.identity);
    }
    public void AnimationOn(int n, float timer = 0f)
    {
        OnOffs[n].SetActive(true);
        if (n == 4)
            animator.SetTrigger("rebirth");
        if(timer != 0f)
            StartCoroutine(AnimationOffC(n, timer));
    }
    public void AnimationOff(int n)
    {
        OnOffs[n].SetActive(false);
    }
        IEnumerator AnimationOffC(int n,float timer = 0f)
    {
        yield return new WaitForSeconds(timer);
        OnOffs[n].SetActive(false);
    }



}
