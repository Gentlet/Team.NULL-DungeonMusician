using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Presets;
using UnityEditor;
public static class ExtensionMethods {
    [MenuItem("GameObject/2D Object/SpriteButton")]
    public static void objectasd ()
    {
        Debug.Log("asdwf");
     }


    public static bool LoadPreset(Object source, Object target)
    {
        Preset preset = new Preset(source);
        return preset.ApplyTo(target);
    }
    public static Component CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }
    public static T CopyComponentTemplet<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }
}
