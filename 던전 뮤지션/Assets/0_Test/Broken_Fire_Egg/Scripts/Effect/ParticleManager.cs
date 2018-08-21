using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {
    public GameObject[] BossParticles; //보스용 파티클 (위치 맞춰주셈)
    public GameObject[] bundles;       //단일 파티클(알아서 꺼짐), (좌표설정 해주셈)
    public GameObject[] longnote;      //롱 노트용 파티클 (4개다 위치 맞춰주셈)(끄는 함수 호출 해주셈)
    public GameObject[] loopingParticle;//루핑하는 파티클 (타이머를 지정 or 끄는 함수 호출 해주셈),(위치 맞춰주셈)
    

    public void PlayParticle(int n, Vector2 position_)
    {
        Instantiate(bundles[0], position_, Quaternion.identity);
    }

    public void BossEffectParticle(int n, Vector2 position_)
    {
        Instantiate(BossParticles[0], position_, Quaternion.identity);
    }

    public void longNoteDown(int n)
    {
        longnote[n].SetActive(true);
    
    }

    public void longNoteUp(int n)
    {
        longnote[n].SetActive(false);
    }

    public void OnloopingParticle(int n,float timer = 0f)
    {
        loopingParticle[n].SetActive(true);
        if(timer != 0f)
        {
            StartCoroutine(OffloopingParticleC(n,timer));
        }
    }
    public void OffloopingParticle(int n)
    {
        StartCoroutine(OffloopingParticleC(n));
    }
   public IEnumerator OffloopingParticleC(int n,float timer = 0f)
    {
        
        yield return new WaitForSecondsRealtime(timer);
        loopingParticle[n].SetActive(false);

    }

}
