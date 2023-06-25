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

    public void ResetPosition()
    {
        foreach (GameObject furniture in raumplanerIcons)
        {
            furniture.transform.position = furniture.GetComponent<DragObject>().startPosition;
            furniture.transform.rotation = furniture.GetComponent<DragObject>().startRotation;
        } 
    }

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

    public void SellFurniture()
    {
        if (raumplanerIcons[0].tag == "Sell")
        {
            raumplanerPics[0].SetActive(true);
            raumplanerDes[0].SetActive(true);

            verkaufsportalPics[0].SetActive(false);
            verkaufsportalDes[0].SetActive(false);
        }
        else
        {
            raumplanerPics[0].SetActive(false);
            raumplanerDes[0].SetActive(false);

            verkaufsportalPics[0].SetActive(true);
            verkaufsportalDes[0].SetActive(true);
        }   

        if (raumplanerIcons[1].tag == "Sell")
        {
            raumplanerPics[1].SetActive(true);
            raumplanerDes[1].SetActive(true);

            verkaufsportalPics[1].SetActive(false);
            verkaufsportalDes[1].SetActive(false);
        }
        else
        {
            raumplanerPics[1].SetActive(false);
            raumplanerDes[1].SetActive(false);

            verkaufsportalPics[1].SetActive(true);
            verkaufsportalDes[1].SetActive(true);
        } 

        if (raumplanerIcons[2].tag == "Sell")
        {
            raumplanerPics[2].SetActive(true);
            raumplanerDes[2].SetActive(true);

            verkaufsportalPics[2].SetActive(false);
            verkaufsportalDes[2].SetActive(false);
        }
        else
        {
            raumplanerPics[2].SetActive(false);
            raumplanerDes[2].SetActive(false);

            verkaufsportalPics[2].SetActive(true);
            verkaufsportalDes[2].SetActive(true);
        } 

        if (raumplanerIcons[3].tag == "Sell")
        {
            raumplanerPics[3].SetActive(true);
            raumplanerDes[3].SetActive(true);

            verkaufsportalPics[3].SetActive(false);
            verkaufsportalDes[3].SetActive(false);
        }
        else
        {
            raumplanerPics[3].SetActive(false);
            raumplanerDes[3].SetActive(false);

            verkaufsportalPics[3].SetActive(true);
            verkaufsportalDes[3].SetActive(true);
        } 

        if (raumplanerIcons[4].tag == "Sell")
        {
            raumplanerPics[4].SetActive(true);
            raumplanerDes[4].SetActive(true);

            verkaufsportalPics[4].SetActive(false);
            verkaufsportalDes[4].SetActive(false);
        }
        else
        {
            raumplanerPics[4].SetActive(false);
            raumplanerDes[4].SetActive(false);

            verkaufsportalPics[4].SetActive(true);
            verkaufsportalDes[4].SetActive(true);
        } 

        if (raumplanerIcons[5].tag == "Sell")
        {
            raumplanerPics[5].SetActive(true);
            raumplanerDes[5].SetActive(true);

            verkaufsportalPics[5].SetActive(false);
            verkaufsportalDes[5].SetActive(false);
        }
        else
        {
            raumplanerPics[5].SetActive(false);
            raumplanerDes[5].SetActive(false);

            verkaufsportalPics[5].SetActive(true);
            verkaufsportalDes[5].SetActive(true);
        } 
    }
}
