using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggleGroup : MonoBehaviour
{
    public Toggle[] toggles;
    public int togglecount;

    private void Start()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            int tempInt = i;

            toggles[i].onValueChanged.AddListener((a) =>  ToggleValueChanged(tempInt) );
        }
    }

    private void ToggleValueChanged(int a)
    {
        int curtoggled = 0;

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
                curtoggled++;
        }

        int j = 0;
        while (curtoggled > togglecount)
        {
            if (j == a)
            {
                j++;
                continue;
            }
            else if (toggles[j].isOn)
            {
                toggles[j].isOn = false;
                curtoggled--;
            }

            j++;
        }
        
    }
}
