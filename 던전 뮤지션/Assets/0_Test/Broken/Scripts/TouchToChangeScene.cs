using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchToChangeScene : MonoBehaviour
{
    public float fadespeed;
    public int scenenumber;
    public Image coverimage;

    bool istouched;

    void Update()
    {
        if ((Input.GetMouseButton(0) || Input.touchCount > 0) && !istouched)
        {
            istouched = true;
        }

        if (istouched)
        {
            float alpha = coverimage.color.a;
            Color tempColor = coverimage.color;

            alpha += fadespeed;

            coverimage.color = new Color(tempColor.r, tempColor.g, tempColor.b, alpha);

            if (coverimage.color.a >= 1)
                SceneManager.LoadScene(1);
        }
    }
}
