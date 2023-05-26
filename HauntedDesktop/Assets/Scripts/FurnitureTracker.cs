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
            des_couch.SetActive(false);
        }
        if (sellArmchair == true)
        {
            pic_armchair.SetActive(true);
            des_armchair.SetActive(false);
        }
        if (sellTable == true)
        {
            pic_table.SetActive(true);
            des_table.SetActive(false);
        }
        if (sellSidetable == true)
        {
            pic_sidetable.SetActive(true);
            des_sidetable.SetActive(false);
        }
        if (sellShelf == true)
        {
            pic_shelf.SetActive(true);
            des_shelf.SetActive(false);
        }
        if (sellLamp == true)
        {
            pic_lamp.SetActive(true);
            des_lamp.SetActive(false);
        }
    }
}
