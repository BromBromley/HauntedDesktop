using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // this script makes the furniture draggable
    // attached to each draggable object

    public Image sprite;
    private RectTransform draggableObject;
    private Vector3 velocity = Vector3.zero;
    private float dampingSpeed = 0.03f;
    private bool dragging = false;

    private GameManager _gameManager;

    private Transform originalParent;

    public  Vector3 startPosition;
    private Quaternion startRotation;

    private float timeSinceStartedReturning = 0f;
    private int timeBeforeReturning;

    public delegate void FurniturePlacedDelegate(DragObject draggable);
    public FurniturePlacedDelegate furniturePlacedCallback;

    private void Awake()
    {
        draggableObject = transform as RectTransform;
        startPosition = draggableObject.position;
        startRotation = draggableObject.rotation;
        //_gridController = grid.GetComponent<GridController>();
        originalParent = draggableObject.transform.parent;
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (dragging == true)
        {
            RotateFurniture();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragging = true;
        draggableObject.tag = "Unassigned";
        draggableObject.SetAsLastSibling();
        draggableObject.SetParent(originalParent);
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
        dragging = false;
        furniturePlacedCallback(this);

        if (_gameManager.isBartyActive)
        {
            StartCoroutine(ReturnToStartPoint());
        }
    }

    public IEnumerator ReturnToStartPoint()
    {
        timeBeforeReturning = Random.Range(1, 4);
        yield return new WaitForSeconds(timeBeforeReturning);
        while (true)
        {
            timeSinceStartedReturning += Time.deltaTime;
            draggableObject.position = Vector3.Lerp(draggableObject.position, startPosition, timeSinceStartedReturning);
            draggableObject.rotation = Quaternion.Lerp(draggableObject.rotation, startRotation, timeSinceStartedReturning);
            if (draggableObject.position == startPosition)
            {
                yield break;
            }
            yield return null;
        }
    }

    private void RotateFurniture()
    {
        if (Input.GetMouseButtonDown(1))
        {
            draggableObject.Rotate(0.0f, 0.0f, 90.0f);
        }
    }
}
