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

    //public Texture2D planchette;

    void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _furnitureTracker = GetComponent<FurnitureTracker>();
        _adChecker = GetComponent<AdChecker>();
        _mouseBehaviour = GetComponent<MouseBehaviour>();
        _mouseBehaviour.enabled = false;        
   }

    /*void Start()
    {
        Cursor.SetCursor(planchette, Vector2.zero, CursorMode.Auto);
    }*/

    public void StartRaumplaner()
    {
        _uiManager.closeEmailArthur();
        _uiManager.openBrowser();
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
        _uiManager.closeBrowser();
        _furnitureTracker.ResetPosition();
    }

    public void StartVerkaufsportal()
    {
        _furnitureTracker.SellFurniture();
        _uiManager.openBrowser();
        _uiManager.openVerkaufsportal();
    }

    public void VerkaufsportalDone()
    {
        _adChecker.CheckIfSortedCorrectly();
        if (_adChecker.correctlySorted)
        {
            StartCoroutine(closingVerkaufsportal());
        }
    }

    IEnumerator closingVerkaufsportal()
    {
        yield return new WaitForSeconds(1);
        _uiManager.closeVerkaufsportal();
        _uiManager.closeBrowser();
        yield return new WaitForSeconds(3);
        StartCoroutine(_uiManager.showingPopUpNewEmail());
    }

    public void StartRaumplanerAgain()
    {
        _uiManager.closeNewEmailArthur();
        _uiManager.openBrowser();
        _uiManager.openRaumplaner();
        StartCoroutine(HauntingInAction());
    }

    IEnumerator HauntingInAction()
    {
        isBartyActive = true;
        _mouseBehaviour.enabled = true;
        StartCoroutine(_mouseBehaviour.BartyActivity());
        //print("haunt is starting");

        yield return new WaitForSeconds(45);

        _mouseBehaviour.fakeCursor.SetActive(false);
        _mouseBehaviour.enabled = false;
        Cursor.visible = true;
        _uiManager.showErrorMessageIcon();
        //print("haunt is over... for now");
    }

    public void OpenVerkaufsportalError()
    {
        if (isBartyActive)
        {
            _uiManager.showErrorMessage();
            isBartyActive = false;
        }
        else
        {
            _uiManager.openVerkaufsportal();
        }
    }
}