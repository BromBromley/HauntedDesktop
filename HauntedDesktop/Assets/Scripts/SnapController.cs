using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    // this script manages the snapping of the ad pictures and descriptions
    // attached to the snapPoints parents

    public List<Transform> snapPoints;
    public List<DragAds> dragAds;
    public List<DragObject> dragObject;
    public int snapRange = 175;

    void Start()
    {
        foreach(DragAds draggable in dragAds)
        {
            draggable.dragEndedCallback = CheckForSnapPoints;
        }
        foreach(DragObject draggable in dragObject)
        {
            draggable.furniturePlacedCallback = CheckForSnapPoints;
        }
    }

    private void CheckForSnapPoints(DragAds draggable)
    {
        float closestDistance = -1;

        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.position, snapPoint.transform.position);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange && closestSnapPoint.transform.childCount == 0)
        {
            draggable.transform.position = closestSnapPoint.transform.position;
            draggable.tag = closestSnapPoint.tag;
            draggable.transform.SetParent(closestSnapPoint);
        }
    }

    private void CheckForSnapPoints(DragObject draggable)
    {
        float closestDistance = -1;

        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.position, snapPoint.transform.position);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange && closestSnapPoint.transform.childCount == 0)
        {
            draggable.transform.position = closestSnapPoint.transform.position;
            draggable.tag = closestSnapPoint.tag;
            draggable.transform.SetParent(closestSnapPoint);
        }
    }
}
