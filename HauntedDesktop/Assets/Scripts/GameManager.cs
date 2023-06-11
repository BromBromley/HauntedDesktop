using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager _uiManager;
    private TabManager _tabManager;
    private FurnitureTracker _furnitureTracker;
    private AdChecker _adChecker;
    private MouseBehaviour _mouseBehaviour;

    public bool isBartyActive;

    //public Texture2D planchette;

    void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _tabManager = FindObjectOfType<TabManager>();
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
        _uiManager.CloseEmailArthur();
        _uiManager.OpenBrowser();
        _uiManager.OpenRaumplaner();
        _tabManager.ShowRaumplanerTab();
    }

    public void RaumplanerOneDone()
    {
        //_furnitureTracker.CheckFurniture();
        StartCoroutine(ClosingRaumplanerOne());
    }

    IEnumerator ClosingRaumplanerOne()
    {
        yield return new WaitForSeconds(1);

        //_uiManager.CloseRaumplaner();
        _uiManager.CloseBrowser();
        _furnitureTracker.ResetPosition();
    }

    public void StartVerkaufsportal()
    {
        _furnitureTracker.SellFurniture();
        _uiManager.OpenBrowser();
        _uiManager.OpenVerkaufsportal();
        _tabManager.ShowVerkaufsportalTab();
    }

    public void VerkaufsportalDone()
    {
        _adChecker.CheckIfSortedCorrectly();
        if (_adChecker.correctlySorted)
        {
            StartCoroutine(ClosingVerkaufsportal());
        }
    }

    IEnumerator ClosingVerkaufsportal()
    {
        yield return new WaitForSeconds(1);
        //_uiManager.CloseVerkaufsportal();
        _uiManager.CloseBrowser();
        yield return new WaitForSeconds(3);
        StartCoroutine(_uiManager.ShowingPopUpNewEmail());
    }

    public void StartRaumplanerAgain()
    {
        _uiManager.CloseNewEmailArthur();
        _uiManager.OpenBrowser();
        //_uiManager.OpenRaumplaner();
        _tabManager.PutRaumplanerOnFront();
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
        _uiManager.ShowErrorMessageIcon();
        //print("haunt is over... for now");
    }

    public void OpenVerkaufsportalError()
    {
        if (isBartyActive)
        {
            _uiManager.ShowErrorMessage();
            _uiManager.CloseRaumplaner();
            isBartyActive = false;
        }
        else
        {
            _uiManager.OpenVerkaufsportal();
        }
    }

    public void ClickOnGeisterscannerAd()
    {
        _uiManager.OpenGeisterscannerWebsite();
        _tabManager.ShowGeisterscannerTab();
        _tabManager.HideRaumplanerTab();
    }
}