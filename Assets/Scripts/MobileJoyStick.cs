using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoyStick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform joyStickTransform;
    
    [SerializeField] private int dragMovementDistance = 30;
    [SerializeField] private int dragOffsetDistance = 100;

    public Vector2 offset;

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joyStickTransform,
            eventData.position,
            null, 
            out offset);
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
        joyStickTransform.anchoredPosition = offset * dragMovementDistance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joyStickTransform.anchoredPosition = Vector2.zero;
        offset = Vector2.zero;
    }

    private void Awake()
    {
        joyStickTransform = (RectTransform)transform;
    }
}
