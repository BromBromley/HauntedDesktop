using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    // this script manages the snapping of the ad pictures and descriptions
    public List<Transform> snapPoints;
    public List<DragAds> dragAds;
    public float snapRange = 5f;

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
                //print(snapPoint);
            }

            /*if (closestSnapPoint !=null)
            {
                //&& closestDistance <= snapRange
                draggable.transform.position = closestSnapPoint.transform.position;
            }*/
        }
    }
}
