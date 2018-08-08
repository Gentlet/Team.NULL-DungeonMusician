using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Presets;
using UnityEditor;
public static class ExtensionMethods {

    [MenuItem("GameObject/2D Object/SpriteButton")]
    public static void objectasd ()
    {
        GameObject GO = Resources.Load("UI/Objects/Button Replace",typeof(GameObject))as GameObject;
        Debug.Log("Create SpriteButton");
        GameObject newGO = MonoBehaviour.Instantiate(GO);
        newGO.name = "SpriteButton";
     }

    
}
