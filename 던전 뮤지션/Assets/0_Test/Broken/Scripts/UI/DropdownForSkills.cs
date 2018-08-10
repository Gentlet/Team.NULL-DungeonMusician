using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownForSkills : MonoBehaviour
{
    Dropdown dropdown;
    public GameObject[] skillUIs;

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged();
        });
    }

    void DropdownValueChanged()
    {
        if (dropdown.value == 0)
        {
            skillUIs[0].SetActive(true);
            skillUIs[1].SetActive(false);
        }
        else if (dropdown.value == 1)
        {
            skillUIs[0].SetActive(false);
            skillUIs[1].SetActive(true);
        }
    }
}
