using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    // this script manages the snapping of the ad pictures and descriptions
    // attached to the snapPoints parents
    public List<Transform> snapPoints;
    public List<DragAds> dragAds;
    public int snapRange = 150;
    private Vector3 startPosition;

    void Start()
    {
        foreach(DragAds draggable in dragAds)
        {
            draggable.dragEndedCallback = CheckForSnapPoints;
            startPosition = draggable.transform.position;
        }
        //startPosition = draggable.transform.position;
    }
    private void CheckForSnapPoints(DragAds draggable)
    {
        float closestDistance = -3;
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

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.position = closestSnapPoint.transform.position;
            print(closestDistance);
            draggable.tag = closestSnapPoint.tag;
        }
        /*else
        {
            draggable.transform.position = startPosition;
        }*/
    }
}
