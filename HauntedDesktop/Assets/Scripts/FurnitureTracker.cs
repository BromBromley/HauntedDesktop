using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureTracker : MonoBehaviour
{
    // this script tracks which furniture will be kept and which sold
    // attached to [GameManager]

    [SerializeField] GameObject[] raumplanerIcons;
    [SerializeField] GameObject[] raumplanerPics;
    [SerializeField] GameObject[] raumplanerDes;
    [SerializeField] GameObject[] verkaufsportalPics;
    [SerializeField] GameObject[] verkaufsportalDes;

    // resets the raumplaner furniture when GameManager calls it
    public void ResetPosition()
    {
        foreach (GameObject furniture in raumplanerIcons)
        {
            furniture.transform.position = furniture.GetComponent<DragObject>().startPosition;
            furniture.transform.rotation = furniture.GetComponent<DragObject>().startRotation;
        } 
    }

    // resets the ad pictures and descriptions when GameManager calls it
    public void ResetAdPosition()
    {
        foreach (GameObject ad in verkaufsportalPics)
        {
            ad.transform.position = ad.GetComponent<DragAds>().startPositionAd;
        }
        foreach (GameObject ad in verkaufsportalDes)
        {
            ad.transform.position = ad.GetComponent<DragAds>().startPositionAd;
        }
        foreach (GameObject ad in raumplanerPics)
        {
            ad.transform.position = ad.GetComponent<DragAds>().startPositionAd;
        }
        foreach (GameObject ad in raumplanerDes)
        {
            ad.transform.position = ad.GetComponent<DragAds>().startPositionAd;
        }
    }

    // activates the furniture that should be sold or its counterpart for ebooh
    public void SellFurniture()
    {
        for (int i = 0; i < 6; i++)
        {
            if (raumplanerIcons[i].tag == "Sell")
            {
                raumplanerPics[i].SetActive(true);
                raumplanerDes[i].SetActive(true);

                verkaufsportalPics[i].SetActive(false);
                verkaufsportalDes[i].SetActive(false);
            }
        else
            {
                raumplanerPics[i].SetActive(false);
                raumplanerDes[i].SetActive(false);

                verkaufsportalPics[i].SetActive(true);
                verkaufsportalDes[i].SetActive(true);
            } 
        }
    }
}
