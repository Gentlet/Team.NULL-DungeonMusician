using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {
    public ParticleSystem[] PSs;
    private void Awake()
    {
        PSs = GetComponentsInChildren<ParticleSystem>();
    }
    public void PlayAll()
    {
        foreach(ParticleSystem tmp in PSs)
        {
            tmp.Play();
        }
    }
    public void DisableAll()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (PSs.Length == 0)
            Destroy(gameObject);
    }

}
