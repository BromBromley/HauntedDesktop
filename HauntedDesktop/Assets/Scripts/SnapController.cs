using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    // this script manages the snapping of the ad pictures and descriptions
    // attached to the snapPoints parents
    public List<Transform> snapPoints;
    public List<DragAds> dragAds;
    public float snapRange = 50f;

    void Start()
    {
        foreach(DragAds draggable in dragAds)
        {
            draggable.dragEndedCallback = CheckForSnapPoints;
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

            /*if (closestSnapPoint !=null)
            {
                print(closestSnapPoint);
                //&& closestDistance <= snapRange
                draggable.transform.position = closestSnapPoint.transform.position;
            }*/
        }

        if (closestSnapPoint != null)
            {
                draggable.transform.position = closestSnapPoint.transform.position;
                //change tag to the one from the snapPoint
                draggable.tag = closestSnapPoint.tag;
            }
    }
}
