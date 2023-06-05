using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureTracker : MonoBehaviour
{
    // this script tracks what furniture is placed and which will be sold
    // attached to [GameManager]

    public bool sellCouch = false;
    public bool sellArmchair = false;
    public bool sellTable = false;
    public bool sellSidetable = false;
    public bool sellShelf = false;
    public bool sellLamp = false;

    [SerializeField] GameObject icon_couch;
    [SerializeField] GameObject icon_armchair;
    [SerializeField] GameObject icon_table;
    [SerializeField] GameObject icon_sidetable;
    [SerializeField] GameObject icon_shelf;
    [SerializeField] GameObject icon_lamp;

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

    private Vector3 border = new Vector3(1000f, 0.0f, 0.0f);


    public void CheckFurniture()
    {
        if (icon_couch.transform.position.x <= border.x)
        {
            sellCouch = true;
        }
        if (icon_armchair.transform.position.x <= border.x)
        {
            sellArmchair = true;
        }
        if (icon_table.transform.position.x <= border.x)
        {
            sellTable = true;
        }
        if (icon_sidetable.transform.position.x <= border.x)
        {
            sellSidetable = true;
        }
        if (icon_shelf.transform.position.x <= border.x)
        {
            sellShelf = true;
        }
        if (icon_lamp.transform.position.x <= border.x)
        {
            sellLamp = true;
        }
    }

    public void ResetPosition()
    {
        icon_couch.transform.position = icon_couch.GetComponent<DragObject>().startPosition;
        icon_armchair.transform.position = icon_armchair.GetComponent<DragObject>().startPosition;
        icon_table.transform.position = icon_table.GetComponent<DragObject>().startPosition;
        icon_sidetable.transform.position = icon_sidetable.GetComponent<DragObject>().startPosition;
        icon_shelf.transform.position = icon_shelf.GetComponent<DragObject>().startPosition;
        icon_lamp.transform.position = icon_lamp.GetComponent<DragObject>().startPosition;
    }

    public void SellFurniture()
    {
        if (sellCouch == true)
        {
            pic_couch.SetActive(true);
            des_couch.SetActive(true);

            pic_vase02.SetActive(false);
            des_vase02.SetActive(false);
        }
        else
        {
            pic_couch.SetActive(false);
            des_couch.SetActive(false);

            pic_vase02.SetActive(true);
            pic_vase02.SetActive(true);
        }   
        if (sellArmchair == true)
        {
            pic_armchair.SetActive(true);
            des_armchair.SetActive(true);

            pic_tablelamp.SetActive(false);
            des_tablelamp.SetActive(false);
        }
        if (sellTable == true)
        {
            pic_table.SetActive(true);
            des_table.SetActive(true);

            pic_mirror.SetActive(false);
            des_mirror.SetActive(false);
        }
        if (sellSidetable == true)
        {
            pic_sidetable.SetActive(true);
            des_sidetable.SetActive(true);

            pic_vase01.SetActive(false);
            des_vase01.SetActive(false);
        }
        if (sellShelf == true)
        {
            pic_shelf.SetActive(true);
            des_shelf.SetActive(true);

            pic_stool.SetActive(false);
            des_stool.SetActive(false);
        }
        if (sellLamp == true)
        {
            pic_lamp.SetActive(true);
            des_lamp.SetActive(true);

            pic_chair.SetActive(false);
            des_chair.SetActive(false);
        }
    }
}
