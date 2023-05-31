using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager _uiManager;
    private FurnitureTracker _furnitureTracker;
    private AdChecker _adChecker;

    void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _furnitureTracker = GetComponent<FurnitureTracker>();
        _adChecker = GetComponent<AdChecker>();
    }

    public void RaumplanerOneDone()
    {
        _furnitureTracker.CheckFurniture();
        StartCoroutine(closingRaumplanerOne());
    }

    IEnumerator closingRaumplanerOne()
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
        _adChecker.CheckIfSortedCorrectly();
        if (_adChecker.correctlySorted)
        {
            _uiManager.closeVerkaufsportal();
            StartCoroutine(_uiManager.showingPopUpNewEmail());
        }
    }
}