using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdChecker : MonoBehaviour
{
    // this script checks if the photo and description of the ads match
    // attached to 01_Verkaufsportal

    [SerializeField] GameObject pic_couch;
    [SerializeField] GameObject pic_armchair;
    [SerializeField] GameObject pic_table;
    [SerializeField] GameObject pic_sidetable;
    [SerializeField] GameObject pic_shelf;
    [SerializeField] GameObject pic_lamp;

    [SerializeField] GameObject des_couch;
    [SerializeField] GameObject des_armchair;
    [SerializeField] GameObject des_table;
    [SerializeField] GameObject des_sidetable;
    [SerializeField] GameObject des_shelf;
    [SerializeField] GameObject des_lamp;

    [SerializeField] GameObject pic_vase01;
    [SerializeField] GameObject pic_vase02;
    [SerializeField] GameObject pic_tablelamp;
    [SerializeField] GameObject pic_chair;
    [SerializeField] GameObject pic_mirror;
    [SerializeField] GameObject pic_stool;

    [SerializeField] GameObject des_vase01;
    [SerializeField] GameObject des_vase02;
    [SerializeField] GameObject des_tablelamp;
    [SerializeField] GameObject des_chair;
    [SerializeField] GameObject des_mirror;
    [SerializeField] GameObject des_stool;

    private int tracker;
    public bool correctlySorted;

    public void CheckForCorrectFurniture()
    {
        if (pic_couch.tag == des_couch.tag && pic_couch.tag != "Unassigned")
        {
            pic_couch.GetComponent<DragAds>().enabled = false;
            des_couch.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_armchair.tag == des_armchair.tag && pic_armchair.tag != "Unassigned")
        {
            pic_armchair.GetComponent<DragAds>().enabled = false;
            des_armchair.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_table.tag == des_table.tag && pic_table.tag != "Unassigned")
        {
            pic_table.GetComponent<DragAds>().enabled = false;
            des_table.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_sidetable.tag == des_sidetable.tag && pic_sidetable.tag != "Unassigned")
        {
            pic_sidetable.GetComponent<DragAds>().enabled = false;
            des_sidetable.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_shelf.tag == des_shelf.tag && pic_shelf.tag != "Unassigned")
        {
            pic_shelf.GetComponent<DragAds>().enabled = false;
            des_shelf.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_lamp.tag == des_lamp.tag && pic_lamp.tag != "Unassigned")
        {
            pic_lamp.GetComponent<DragAds>().enabled = false;
            des_lamp.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_vase01.tag == des_vase01.tag && pic_vase01.tag != "Unassigned")
        {
            pic_vase01.GetComponent<DragAds>().enabled = false;
            des_vase01.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_vase02.tag == des_vase02.tag && pic_vase02.tag != "Unassigned")
        {
            pic_vase02.GetComponent<DragAds>().enabled = false;
            des_vase02.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_tablelamp.tag == des_tablelamp.tag && pic_tablelamp.tag != "Unassigned")
        {
            pic_tablelamp.GetComponent<DragAds>().enabled = false;
            des_tablelamp.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_chair.tag == des_chair.tag && pic_chair.tag != "Unassigned")
        {
            pic_chair.GetComponent<DragAds>().enabled = false;
            des_chair.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_mirror.tag == des_mirror.tag && pic_mirror.tag != "Unassigned")
        {
            pic_mirror.GetComponent<DragAds>().enabled = false;
            des_mirror.GetComponent<DragAds>().enabled = false;
            tracker++;
        }
        if (pic_stool.tag == des_stool.tag && pic_stool.tag != "Unassigned")
        {
            pic_stool.GetComponent<DragAds>().enabled = false;
            des_stool.GetComponent<DragAds>().enabled = false;
            tracker++;
        }

        if (tracker == 36)
        {
            correctlySorted = true;
        }
    }
}
