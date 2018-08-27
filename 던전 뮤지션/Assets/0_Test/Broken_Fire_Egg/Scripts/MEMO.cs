using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEMO : MonoBehaviour {
    //new Vector2(0,3.36f) 몬스터 대략 좌표
    //new Vector2(0,3.36f) 스킬:스크림 대략 좌표
    public void Start()
    {
        // ParticleManager.instance.PlayParticle(1, new Vector2(0, 3.36f));
       // AnimationManager.instance.AnimationInstantiate(4, new Vector2(0, 3.36f));
    }
    public ObjectStatus[] objects;

    public void Actuallyrevive()
    {

    }
    public void KillEnemy()
    {
        Busking.instance.Off();
    }
}
