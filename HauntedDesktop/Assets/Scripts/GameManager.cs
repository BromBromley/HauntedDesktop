using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool raumplanerIsActive = true;

    private FurnitureTracker _furnitureTracker;
    private UIManager _uiManager;
    private AdChecker _adChecker;

    void Awake()
    {
        _furnitureTracker = GetComponent<FurnitureTracker>();
        _uiManager = FindObjectOfType<UIManager>();
        _adChecker = FindObjectOfType<AdChecker>();
    }

    public void RaumplanerOneDone()
    {
        raumplanerIsActive = false;
        _furnitureTracker.CheckFurniture();
        StartCoroutine(closeRaumplanerOne());
    }

    IEnumerator closeRaumplanerOne()
    {
        yield return new WaitForSeconds(1);

        _uiManager.closeRaumplaner();
        _furnitureTracker.ResetPosition();
    }

    public void StartVerkaufsportal()
    {
        _furnitureTracker.SellFurniture();
        _uiManager.openVerkaufsportal();
    }

    public void VerkaufsportalDone()
    {
        if (_adChecker.correctlySorted)
        {
            _uiManager.closeVerkaufsportal();
        }
    }
}