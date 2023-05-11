using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // this script makes UI elements draggable

    //private PlayerControls _playerControls;

    public Image sprite;
    private RectTransform draggableObject;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float dampingSpeed = 0.03f;

    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] private GridBehavior gridBehavior;
    public float snapRange = 0.5f;

    public delegate void DragEndedDelegate(DragObject draggableObjects);
    public DragEndedDelegate dragEndedCallback;

    private void Awake()
    {
        //_playerControls = FindObjectOfType<PlayerControls>();
        draggableObject = transform as RectTransform;
        gridBehavior = FindObjectOfType<GridBehavior>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        sprite.raycastTarget = false;
        parentAfterDrag = transform.parent;
        //transform.SetParent(transform.parent.parent);
        //transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggableObject, eventData.position, eventData.pressEventCamera, out var mousePosition))
        {
            draggableObject.position = Vector3.SmoothDamp(draggableObject.position, mousePosition, ref velocity, dampingSpeed);
        }
        /*if (_playerControls.RightClick)
        {
            transform.Rotate(90.0f, 0.0f, 0.0f);
        }*/
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("placed");
        sprite.raycastTarget = true;
        //dragEndedCallback(this);
        //transform.SetParent(parentAfterDrag);
        //sfx
        //tracker
        //CheckForSnapPoints();
    }
    
    /*private void CheckForSnapPoints()
    {
        float closestDistance = -1;
        gridBehavior.Transform closestSnapPoint = null;

        foreach (gridBehavior.Transform snapPoint in gridBehavior.snapPoints)
        {
            float currentDistance = Vector2.Distance(draggableObject.transform.position, gridBehavior.snapPoints.position);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = gridBehavior.snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint !=null && closestDistance <= snapRange)
        {
            draggableObject.transform.position = closestSnapPoint.position;
        }
    }*/
}
