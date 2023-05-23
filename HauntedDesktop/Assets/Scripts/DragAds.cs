using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAds : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // makes the ad photos and descritpions draggable 
    public Image sprite;
    private RectTransform draggableObject;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float dampingSpeed = 0.03f;

    public float snapRange = 0.5f;
    public delegate void DragEndedDelegate(DragAds draggable);
    public DragEndedDelegate dragEndedCallback;

    private void Awake()
    {
        draggableObject = transform as RectTransform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        sprite.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggableObject, eventData.position, eventData.pressEventCamera, out var mousePosition))
        {
            draggableObject.position = Vector3.SmoothDamp(draggableObject.position, mousePosition, ref velocity, dampingSpeed);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        sprite.raycastTarget = true;
        dragEndedCallback(this);
    }
}
