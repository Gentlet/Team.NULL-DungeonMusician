using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public GameObject []Effects;
    [Range(0f, 10f)]
    public float randomx;
    [Range(0f, 10f)]
    public float randomy;
    void PlayEffectOne(int index,float offsetx = 0f,float offsety = 0f)
    {
        GameObject GO = Instantiate(Effects[index],new Vector3(offsetx,offsety)+new Vector3(randomx,randomy),
            Quaternion.identity,EnemyManager.Instance.Enemy.transform);
        GO.SetActive(true);
        
    }
    IEnumerator PlayEffectMany(int index, int amount, float delay=0f)
    {

        WaitForSeconds WS = new WaitForSeconds(delay);
        int n = 0;
        while (n < amount)
        {
            PlayEffectOne(index);
            yield return WS;
        }
    }
    public void PlayEffect(int num)
    {
        switch(num)
        {
            case 0:
                break;

            case 1:
                break;

            default: //단일 이펙트 일때
                PlayEffectOne(num);
                break;
        }
    }

}
