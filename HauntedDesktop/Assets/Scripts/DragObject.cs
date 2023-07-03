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

    private RectTransform draggableObject;
    [SerializeField] private GameObject picture;
    private Vector3 velocity = Vector3.zero;
    private float dampingSpeed = 0.03f;
    private bool dragging = false;

    private GameManager _gameManager;

    private Transform originalParent;

    private  Vector3 startPosition;
    private Quaternion startRotation;

    private float timeSinceStartedReturning = 0f;
    private int timeBeforeReturning;

    public delegate void FurniturePlacedDelegate(DragObject draggable);
    public FurniturePlacedDelegate furniturePlacedCallback;

    private void Awake()
    {
        draggableObject = transform as RectTransform;
        picture.SetActive(false);
        startPosition = draggableObject.position;
        startRotation = draggableObject.rotation;
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
            if (draggableObject.transform.position.x < 1025)
            {
                picture.SetActive(true);
                draggableObject.GetComponent<Image>().enabled = false;
            }
            else
            {
                picture.SetActive(false);
                draggableObject.GetComponent<Image>().enabled = true;
            }
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
        HidePicture();
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
            picture.transform.Rotate(0.0f, 0.0f, -90.0f);
        }
    }

    private void HidePicture()
    {
        picture.SetActive(false);
        draggableObject.GetComponent<Image>().enabled = true;
    }

    public void ResetPositionAndRotation()
    {
        draggableObject.position = startPosition;
        draggableObject.transform.rotation = startRotation;
        picture.transform.rotation = startRotation;
        HidePicture();
    }
}
