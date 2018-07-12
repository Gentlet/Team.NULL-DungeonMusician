using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] UIs;

    public void disableAllToggleUIs()
    {
        for (int i = 0; i < UIs.Length; i++)
            UIs[i].SetActive(false);
    }
    public void enableToggleUI(int num)
    {
        UIs[num].SetActive(true);
    }

    public void toggleVisibility(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
    public void turnOnVisibility(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void turnOffVisibility(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
