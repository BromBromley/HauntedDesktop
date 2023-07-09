using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAds : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // this script makes the ad photos and descritpions draggable 
    // attached to each photo and description

    private RectTransform draggableObject;
    private Vector3 velocity = Vector3.zero;
    private float dampingSpeed = 0.03f;
    private AdChecker _adChecker;

    private Transform originalParent;
    public  Vector3 startPositionAd;

    public delegate void DragEndedDelegate(DragAds draggable);
    public DragEndedDelegate dragEndedCallback;

    private void Awake()
    {
        draggableObject = transform as RectTransform;
        _adChecker = FindObjectOfType<AdChecker>();
        originalParent = draggableObject.transform.parent;
        startPositionAd = draggableObject.position;
    }

    public void ResetParent()
    {
        draggableObject.SetParent(originalParent);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggableObject.tag = "Unassigned";
        draggableObject.SetAsLastSibling();
        ResetParent();
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
        dragEndedCallback(this);
        _adChecker.CheckForCorrectFurniture();
    }
}
