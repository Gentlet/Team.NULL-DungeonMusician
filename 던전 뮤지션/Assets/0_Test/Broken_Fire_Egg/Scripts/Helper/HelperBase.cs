using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperBase : ObjectStatus
{
    //다른 조력자들의 데미지를 total%만큼 올려줌
    //다른 조력자들이 버프를 받기 위해 이 클래스를 참조한다
    //그래서 초기화 말곤 아무것도 할게 없어 보인다.
    public static HelperBase instance;
    
    new void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        base.Awake();
        
        fomula = true;
        basepoint = 1;
        upgraderate = 1;
        parambase = 1;
        paramrate = 1;
    }
}
