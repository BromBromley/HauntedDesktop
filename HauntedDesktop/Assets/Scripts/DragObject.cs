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

    [SerializeField] private GameObject grid;
    private GridController _gridController;
    private GameManager _gameManager;

    public float snapRange = 0.5f;

    public Vector3 startPosition;
    public Quaternion startRotation;

    private void Awake()
    {
        draggableObject = transform as RectTransform;
        startPosition = draggableObject.position;
        startRotation = draggableObject.rotation;
        _gridController = grid.GetComponent<GridController>();
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
        draggableObject.SetAsLastSibling();
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
        //CheckForSnapPoints();

        if (_gameManager.isBartyActive)
        {
            StartCoroutine(ReturnToStartPoint());
        }
    }

    public IEnumerator ReturnToStartPoint()
    {
        yield return new WaitForSeconds(2);
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            draggableObject.position = Vector3.Lerp(draggableObject.position, startPosition, timeSinceStarted);
            draggableObject.rotation = Quaternion.Lerp(draggableObject.rotation, startRotation, timeSinceStarted);
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

    /*private void CheckForSnapPoints(draggableObject)
    {
        float closestDistance = -1;
        _gridBehavior.Transform closestSnapPoint = null;

        foreach (_gridBehavior.Transform snapPoint in _gridBehavior.snapPoints)
        {
            float currentDistance = Vector2.Distance(draggableObject.transform.position, _gridBehavior.snapPoint.transform.position);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = _gridBehavior.snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint !=null && closestDistance <= snapRange)
        {
            draggableObject.transform.position = closestSnapPoint.position;
        }
    }*/
}
