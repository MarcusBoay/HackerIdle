using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipPointerFunctions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    public EventTrigger.TriggerEvent pointerEnter;
    public EventTrigger.TriggerEvent pointerExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerEnter.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerExit.Invoke(eventData);
    }
}
