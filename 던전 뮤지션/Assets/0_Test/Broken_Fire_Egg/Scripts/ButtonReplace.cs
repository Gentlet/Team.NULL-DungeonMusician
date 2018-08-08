using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEditor;

[RequireComponent(typeof(EventTrigger))]
[ExecuteInEditMode]
public class ButtonReplace : MonoBehaviour
{
    float value;
    public float tintFramePer;
    public SpriteRenderer SR;
    bool isout;
    bool mousedown;
    private void Start()
    {
        value = 1f;
        mousedown = false;
        isout = false;
    }
    private void Update()
    {
        if (mousedown)
        {
            if (isout)
            {
                if(value < 1f)
                {
                    value += tintFramePer;
                    SR.color = new Color(value, value, value);
                }
            }
            else
            {
                
               if(value > 0.78431f)
                {
                    value -= tintFramePer;
                    SR.color = new Color(value, value, value);
                }
            }
        }
        else
        {
            if (value < 1f)
            {
                value += tintFramePer;
                SR.color = new Color(value, value, value);
            }
        }
    }
    public void Function()
    {
        Debug.Log(Input.mousePosition);
    }

    public void Down()
    {
        mousedown = true;
    }
    public void Up()
    {
        mousedown = false;
    }
    public void Exit()
    {
        isout = true;
    }
    public void Enter()
    {
        isout = false;
    }
}
