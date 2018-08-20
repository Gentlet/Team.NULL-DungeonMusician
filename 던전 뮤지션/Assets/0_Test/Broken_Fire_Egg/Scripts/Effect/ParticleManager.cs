using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {
    public GameObject[] BossParticles;
    public GameObject[] bundles;
    public GameObject[] longnote;
    public GameObject[] loopingParticle;



    private void Start()
    {
    }

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
        if (timer == 0f)
            loopingParticle[n].SetActive(true);
        else
        {
            StartCoroutine(OffloopingParticleC(n,timer));
        }
    }

   public IEnumerator OffloopingParticleC(int n,float timer = 0f)
    {
        yield return new WaitForSecondsRealtime(timer);
        loopingParticle[n].SetActive(false);

    }

}
