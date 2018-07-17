using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightSkill : ObjectStatus {

    public bool isactive;


    public void ParamUpgrade()
    {
        param++;
    }
    public void Active()
    {
        isactive = true;
        StartCoroutine(Acting());
    }
    public IEnumerator Acting()
    {
        yield return new WaitForSeconds(param);
        isactive = false;
    }


}
