using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Presets;
using UnityEditor;
public static class ExtensionMethods {

    [MenuItem("GameObject/2D Object/SpriteButton")]
    public static void CreateSpriteButton ()
    {
        GameObject newGO = Object.Instantiate(Resources.Load("UI/Objects/Button Replace", typeof(GameObject)) as GameObject);
       if(GameObject.Find("SpriteButton") == null)
            newGO.name = "SpriteButton";
       else
        {
            int n = 1;
            string str;
            while (true)
            {
                n++;
                str = string.Format("SpriteButton ({0})", n - 1);
                if (GameObject.Find(str) == null)
                {
                    newGO.name = str;
                    break;
                }
            }
        }
        Selection.activeGameObject = newGO;
    }

    
}
