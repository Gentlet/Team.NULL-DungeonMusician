using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busking : ObjectStatus {
    //base 추가%
    public bool isActive;
    public void Start()
    {
        isActive = false;
    }

    public void Active()
    {
        isActive = true;
    }
}
