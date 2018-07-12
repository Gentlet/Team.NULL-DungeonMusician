using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ToggleType
{
    BGM,
    SFX
}

public class SoundToggle : MonoBehaviour
{
    public ToggleType type;

    private Toggle thisToggle;

    private void Start()
    {
        thisToggle = GetComponent<Toggle>();

        if (type == ToggleType.BGM)
        {
            if (PlayerPrefs.GetInt("IsBGMOn", 1) == 1)
                thisToggle.isOn = true;
            else
                thisToggle.isOn = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("IsEffectOn", 1) == 1)
                thisToggle.isOn = true;
            else
                thisToggle.isOn = false;
        }

        thisToggle.onValueChanged.AddListener((a) => onChanged(type));
    }

    private void onChanged(ToggleType a)
    {
        if (a == ToggleType.BGM)
        {
            if (PlayerPrefs.GetInt("IsBGMOn", 1) == 1)
            {
                PlayerPrefs.SetInt("IsBGMOn", 0);
                Debug.Log("Changed BGM to FALSE");
            }
            else
            {
                PlayerPrefs.SetInt("IsBGMOn", 1);
                Debug.Log("Changed BGM to TRUE");
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("IsEffectOn", 1) == 1)
            {
                PlayerPrefs.SetInt("IsEffectOn", 0);
                Debug.Log("Changed SFX to FALSE");
            }
            else
            {
                PlayerPrefs.SetInt("IsEffectOn", 1);
                Debug.Log("Changed SFX to TRUE");
            }
        }
    }
}
