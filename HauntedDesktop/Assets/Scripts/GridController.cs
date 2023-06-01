using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridController : MonoBehaviour
{
    public List<Transform> snapPoints;
    //public List<DragObject> draggableObjects;
    public float snapRange = 0.5f;
    public DragObject dragObject;

    public void CheckForSnapPoints()
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(dragObject.transform.position, snapPoint.transform.position);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint !=null && closestDistance <=snapRange)
        {
            dragObject.transform.localPosition = closestSnapPoint.localPosition;
        }
    }
}
