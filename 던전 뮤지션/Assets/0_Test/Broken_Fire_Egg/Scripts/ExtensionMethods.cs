using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public static class ExtensionMethods {
    public static void AddEventTriggerListener(this EventTrigger trigger, EventTriggerType eventType,
        UnityEngine.Events.UnityAction<BaseEventData> listener)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(listener);
        trigger.triggers.Add(entry);
        Debug.Log(eventType.ToString());
    }
}
