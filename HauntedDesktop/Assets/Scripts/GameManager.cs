using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager _uiManager;
    private FurnitureTracker _furnitureTracker;
    private AdChecker _adChecker;
    private MouseBehaviour _mouseBehaviour;

    public bool isBartyActive;

    public Texture2D planchette;

    void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _furnitureTracker = GetComponent<FurnitureTracker>();
        _adChecker = GetComponent<AdChecker>();
        _mouseBehaviour = GetComponent<MouseBehaviour>();
    }

    void Start()
    {
        Cursor.SetCursor(planchette, Vector2.zero, CursorMode.Auto);
    }

    public void StartRaumplaner()
    {
        _uiManager.closeEmailArthur();
        _uiManager.openRaumplaner();
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

    public void StartRaumplanerAgain()
    {
        _uiManager.openRaumplaner();
        _uiManager.closeNewEmailArthur();
        StartCoroutine(HauntingInAction());
    }

    IEnumerator HauntingInAction()
    {
        // activate Barty's haunting behaviour
        // activate furniture returning to its original position
        isBartyActive = true;
        print("haunt is starting");

        yield return new WaitForSeconds(40);

        // show Verkaufsportal pop up
        _uiManager.showErrorMessageIcon();
        print("haunt is over... for now");
    }

    public void OpenVerkaufsportalError()
    {
        if (isBartyActive)
        {
            _uiManager.showErrorMessage();
            isBartyActive = false;
        }
    }
}