using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdChecker : MonoBehaviour
{
    // this script checks if the photo and description of the ads match
    // attached to [GameManager]

    [SerializeField] GameObject[] pics_raumplaner;
    [SerializeField] GameObject[] des_raumplaner;
    [SerializeField] GameObject[] pics_verkaufsportal;
    [SerializeField] GameObject[] des_verkaufsportal;

    [SerializeField] public GameObject postButton;

    private int tracker = 0;
    public bool correctlySorted = false;

    // called by DragAds; checks if they match at the end of each drag 
    public void CheckForCorrectFurniture()
    {
        postButton.SetActive(true);
        
        for (int i = 0; i < 6; i++)
        {
            if (pics_raumplaner[i].tag == des_raumplaner[i].tag && pics_raumplaner[i].tag != "Unassigned")
            {
                if (pics_raumplaner[i].GetComponent<DragAds>().enabled == true)
                {
                    tracker++;
                }
                pics_raumplaner[i].GetComponent<DragAds>().enabled = false;
                des_raumplaner[i].GetComponent<DragAds>().enabled = false;
            }
        }
        for (int i = 0; i < 6; i++)
        {
            if (pics_verkaufsportal[i].tag == des_verkaufsportal[i].tag && pics_verkaufsportal[i].tag != "Unassigned")
            {
                if (pics_verkaufsportal[i].GetComponent<DragAds>().enabled == true)
                {
                    tracker++;
                }
                pics_verkaufsportal[i].GetComponent<DragAds>().enabled = false;
                des_verkaufsportal[i].GetComponent<DragAds>().enabled = false;
            }
        }

        CheckIfSortedCorrectly();
    }
    
    public void CheckIfSortedCorrectly()
    {
        if (tracker == 6)
        {
            correctlySorted = true;
        }
    }

    // called by GameManager after clicking on the link in the error email
    // resets everything on ebooh to the way it was in the beginning
    public void ResetAdChecker()
    {
        postButton.SetActive(true);
        tracker = 0;
        correctlySorted = false;

        foreach (GameObject picture in pics_raumplaner)
        {
            picture.tag = "Unassigned";
            picture.GetComponent<DragAds>().enabled = true;
            picture.GetComponent<DragAds>().ResetParent();
        } 
        foreach (GameObject description in des_raumplaner)
        {
            description.tag = "Unassigned";
            description.GetComponent<DragAds>().enabled = true;
            description.GetComponent<DragAds>().ResetParent();
        } 
        foreach (GameObject picture in pics_verkaufsportal)
        {
            picture.tag = "Unassigned";
            picture.GetComponent<DragAds>().enabled = true;
            picture.GetComponent<DragAds>().ResetParent();
        } 
        foreach (GameObject description in des_verkaufsportal)
        {
            description.tag = "Unassigned";
            description.GetComponent<DragAds>().enabled = true;
            description.GetComponent<DragAds>().ResetParent();
        } 
    }
}
