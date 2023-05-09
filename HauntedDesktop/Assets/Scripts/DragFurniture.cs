using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragFurniture : MonoBehaviour
{
    // this script hopefully makes the furniture draggable
    //IBeginDragHandler, IDragHandler, IEndDragHandler

    //private new vector3 mousePosition;

    //public void OnBeginDrag(PointerEventData eventData)

    private bool isDragged = false;

    private Vector2 mouseDragPosition;
    private Vector2 spritePosition;

    /*void OnDrag(PointerEventData eventData)
    {
        print("started dragging");
        isDragged = true;
        //mouseDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDragPosition = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDragged)
        {
            print("dragging");
            //transform.localPosition = spritePosition + (Camera.main.ScreenToViewportPoint(Input.mousePosition) - mouseDragPosition);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("dragged");
        isDragged = false;
    }*/

    /*public void GetDragged()
    {
        var mousePosition = Mouse.current.position.ReadValue();
        print(mousePosition);
    }*/
}
