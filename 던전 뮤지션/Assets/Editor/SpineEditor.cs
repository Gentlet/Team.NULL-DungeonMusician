//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//[CustomEditor(typeof(SpineAnimationManager))]
//public class SpineEditor : Editor {

//    SpineAnimationManager _SAM;
//    private void OnEnable()
//    {
//        _SAM = target as SpineAnimationManager;
//    }
//    public override void OnInspectorGUI()
//    {
//        EditorGUILayout.BeginHorizontal();
//        EditorGUILayout.LabelField("Type","");
//        string[] Typenames = new string[] { "Canvas", "NotCanvas" };
//        int[] values = new int[] { 0, 1 };
//        _SAM._type = EditorGUILayout.IntPopup(_SAM._type, Typenames, values);
//        EditorGUILayout.EndHorizontal();
//        if(GUI.changed)
//        {
//            EditorUtility.SetDirty(target);
//        }
//        //base.OnInspectorGUI();
//    }
//}
