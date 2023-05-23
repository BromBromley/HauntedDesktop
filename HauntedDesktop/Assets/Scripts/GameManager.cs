using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool raumplanerIsActive = true;


    private FurnitureTracker _furnitureTracker;

    void Awake()
    {
        _furnitureTracker = GetComponent<FurnitureTracker>();
    }

    public void RaumplanerOneDone()
    {
        raumplanerIsActive = false;
        //FurnitureTracker.CheckFurniture();
    }
}
