using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdChecker : MonoBehaviour
{
    // this script checks if the photo and description of the ads match
    // attached to [GameManager]

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

    [SerializeField] public GameObject postButton;

    private int tracker = 0;
    public bool correctlySorted = false;

    public void CheckForCorrectFurniture()
    {
        postButton.SetActive(true);
        if (pic_couch.tag == des_couch.tag && pic_couch.tag != "Unassigned")
        {
            if (pic_couch.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_couch.GetComponent<DragAds>().enabled = false;
            des_couch.GetComponent<DragAds>().enabled = false;
        }
        if (pic_armchair.tag == des_armchair.tag && pic_armchair.tag != "Unassigned")
        {
            if (pic_armchair.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_armchair.GetComponent<DragAds>().enabled = false;
            des_armchair.GetComponent<DragAds>().enabled = false;
        }
        if (pic_table.tag == des_table.tag && pic_table.tag != "Unassigned")
        {
            if (pic_table.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_table.GetComponent<DragAds>().enabled = false;
            des_table.GetComponent<DragAds>().enabled = false;
        }
        if (pic_sidetable.tag == des_sidetable.tag && pic_sidetable.tag != "Unassigned")
        {
            if (pic_sidetable.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_sidetable.GetComponent<DragAds>().enabled = false;
            des_sidetable.GetComponent<DragAds>().enabled = false;
        }
        if (pic_shelf.tag == des_shelf.tag && pic_shelf.tag != "Unassigned")
        {
            if (pic_shelf.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_shelf.GetComponent<DragAds>().enabled = false;
            des_shelf.GetComponent<DragAds>().enabled = false;
        }
        if (pic_lamp.tag == des_lamp.tag && pic_lamp.tag != "Unassigned")
        {
            if (pic_lamp.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_lamp.GetComponent<DragAds>().enabled = false;
            des_lamp.GetComponent<DragAds>().enabled = false;
        }
        if (pic_vase01.tag == des_vase01.tag && pic_vase01.tag != "Unassigned")
        {
            if (pic_vase01.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_vase01.GetComponent<DragAds>().enabled = false;
            des_vase01.GetComponent<DragAds>().enabled = false;
        }
        if (pic_vase02.tag == des_vase02.tag && pic_vase02.tag != "Unassigned")
        {
            if (pic_vase02.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_vase02.GetComponent<DragAds>().enabled = false;
            des_vase02.GetComponent<DragAds>().enabled = false;
        }
        if (pic_tablelamp.tag == des_tablelamp.tag && pic_tablelamp.tag != "Unassigned")
        {
            if (pic_tablelamp.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_tablelamp.GetComponent<DragAds>().enabled = false;
            des_tablelamp.GetComponent<DragAds>().enabled = false;
        }
        if (pic_chair.tag == des_chair.tag && pic_chair.tag != "Unassigned")
        {
            if (pic_chair.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_chair.GetComponent<DragAds>().enabled = false;
            des_chair.GetComponent<DragAds>().enabled = false;
        }
        if (pic_mirror.tag == des_mirror.tag && pic_mirror.tag != "Unassigned")
        {
            if (pic_mirror.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_mirror.GetComponent<DragAds>().enabled = false;
            des_mirror.GetComponent<DragAds>().enabled = false;
        }
        if (pic_stool.tag == des_stool.tag && pic_stool.tag != "Unassigned")
        {
            if (pic_stool.GetComponent<DragAds>().enabled == true)
            {
                tracker++;
            }
            pic_stool.GetComponent<DragAds>().enabled = false;
            des_stool.GetComponent<DragAds>().enabled = false;
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

    public void ResetAdChecker()
    {
        postButton.SetActive(true);
        tracker = 0;
        correctlySorted = false;

        pic_couch.tag = "Unassigned";
        pic_armchair.tag = "Unassigned";
        pic_table.tag = "Unassigned";
        pic_sidetable.tag = "Unassigned";
        pic_shelf.tag = "Unassigned";
        pic_lamp.tag = "Unassigned";
        des_couch.tag = "Unassigned";
        des_armchair.tag = "Unassigned";
        des_table.tag = "Unassigned";
        des_sidetable.tag = "Unassigned";
        des_shelf.tag = "Unassigned";
        des_lamp.tag = "Unassigned";

        pic_vase01.tag = "Unassigned";
        pic_vase02.tag = "Unassigned";;
        pic_tablelamp.tag = "Unassigned";
        pic_chair.tag = "Unassigned";
        pic_mirror.tag = "Unassigned";
        pic_stool.tag = "Unassigned";
        des_vase01.tag = "Unassigned";
        des_vase02.tag = "Unassigned";
        des_tablelamp.tag = "Unassigned";
        des_chair.tag = "Unassigned";
        des_mirror.tag = "Unassigned";
        des_stool.tag = "Unassigned";

        pic_couch.GetComponent<DragAds>().enabled = true;
        pic_armchair.GetComponent<DragAds>().enabled = true;
        pic_table.GetComponent<DragAds>().enabled = true;
        pic_sidetable.GetComponent<DragAds>().enabled = true;
        pic_shelf.GetComponent<DragAds>().enabled = true;
        pic_lamp.GetComponent<DragAds>().enabled = true;
        des_couch.GetComponent<DragAds>().enabled = true;
        des_armchair.GetComponent<DragAds>().enabled = true;
        des_table.GetComponent<DragAds>().enabled = true;
        des_sidetable.GetComponent<DragAds>().enabled = true;
        des_shelf.GetComponent<DragAds>().enabled = true;
        des_lamp.GetComponent<DragAds>().enabled = true;

        pic_vase01.GetComponent<DragAds>().enabled = true;
        pic_vase02.GetComponent<DragAds>().enabled = true;
        pic_tablelamp.GetComponent<DragAds>().enabled = true;
        pic_chair.GetComponent<DragAds>().enabled = true;
        pic_mirror.GetComponent<DragAds>().enabled = true;
        pic_stool.GetComponent<DragAds>().enabled = true;
        des_vase01.GetComponent<DragAds>().enabled = true;
        des_vase02.GetComponent<DragAds>().enabled = true;
        des_tablelamp.GetComponent<DragAds>().enabled = true;
        des_chair.GetComponent<DragAds>().enabled = true;
        des_mirror.GetComponent<DragAds>().enabled = true;
        des_stool.GetComponent<DragAds>().enabled = true;

        pic_couch.GetComponent<DragAds>().ResetParent();
        pic_armchair.GetComponent<DragAds>().ResetParent();
        pic_table.GetComponent<DragAds>().ResetParent();
        pic_sidetable.GetComponent<DragAds>().ResetParent();
        pic_shelf.GetComponent<DragAds>().ResetParent();
        pic_lamp.GetComponent<DragAds>().ResetParent();
        des_couch.GetComponent<DragAds>().ResetParent();
        des_armchair.GetComponent<DragAds>().ResetParent();
        des_table.GetComponent<DragAds>().ResetParent();
        des_sidetable.GetComponent<DragAds>().ResetParent();
        des_shelf.GetComponent<DragAds>().ResetParent();
        des_lamp.GetComponent<DragAds>().ResetParent();

        pic_vase01.GetComponent<DragAds>().ResetParent();
        pic_vase02.GetComponent<DragAds>().ResetParent();
        pic_tablelamp.GetComponent<DragAds>().ResetParent();
        pic_chair.GetComponent<DragAds>().ResetParent();
        pic_mirror.GetComponent<DragAds>().ResetParent();
        pic_stool.GetComponent<DragAds>().ResetParent();
        des_vase01.GetComponent<DragAds>().ResetParent();
        des_vase02.GetComponent<DragAds>().ResetParent();
        des_tablelamp.GetComponent<DragAds>().ResetParent();
        des_chair.GetComponent<DragAds>().ResetParent();
        des_mirror.GetComponent<DragAds>().ResetParent();
        des_stool.GetComponent<DragAds>().ResetParent();
    }
}
