using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureTracker : MonoBehaviour
{
    // this script tracks what furniture is placed and which will be sold
    // attached to [GameManager]

    public bool sellShelf = false;
    public bool sellCouch = false;
    public bool sellTable = false;
    public bool sellSidetable = false;
    public bool sellArmchair = false;
    public bool sellLamp = false;

    [SerializeField] GameObject shelf;
    [SerializeField] GameObject couch;
    [SerializeField] GameObject table;
    [SerializeField] GameObject sidetable;
    [SerializeField] GameObject armchair;
    [SerializeField] GameObject lamp;

    private Vector3 border = new Vector3(1000f, 0.0f, 0.0f);

    public void CheckFurniture()
    {
        if (shelf.transform.position.x >= border.x)
        {
            //Debug.Log("sell shelf");
            sellShelf = true;
        }
        if (couch.transform.position.x >= border.x)
        {
            sellCouch = true;
        }
        if (table.transform.position.x >= border.x)
        {
            sellTable = true;
        }
        if (sidetable.transform.position.x >= border.x)
        {
            sellSidetable = true;
        }
        if (armchair.transform.position.x >= border.x)
        {
            sellArmchair = true;
        }
        if (lamp.transform.position.x >= border.x)
        {
            sellLamp = true;
        }
    }
}
