using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEditor;

[RequireComponent(typeof(EventTrigger))]
[ExecuteInEditMode]
public class ButtonReplace : MonoBehaviour
{
    public EventTrigger ET;
    float value;
    public float tintFramePer;
    public SpriteRenderer SR;
    bool isout;
    bool mousedown;


    public void Setting(PointerEventData data)
    {



    }

    void Awake()
    {
        ET = GetComponent<EventTrigger>();
        ET.triggers.Clear();




        //ExtensionMethods.AddEventTriggerListener(ET, EventTriggerType.PointerEnter, Enter);
        //ExtensionMethods.AddEventTriggerListener(ET, EventTriggerType.PointerExit, Exit);
        //ExtensionMethods.AddEventTriggerListener(ET, EventTriggerType.PointerUp, Up);
        //ExtensionMethods.AddEventTriggerListener(ET, EventTriggerType.PointerDown, Down);

    }
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

    public void Down(PointerEventData data)
    {
        mousedown = true;   
    }
    public void Up(PointerEventData data)
    {
        mousedown = false;
    }
    public void Exit(PointerEventData data)
    {
        isout = true;
    }
    public void Enter(PointerEventData data)
    {
        isout = false;
    }
}
