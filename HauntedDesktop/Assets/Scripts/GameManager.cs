using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject dragBlocker;
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
        dragBlocker.SetActive(false);       
   }

    /*void Start()
    {
        Cursor.SetCursor(planchette, Vector2.zero, CursorMode.Auto);
    }*/

    // activated when link in email is clicked
    public void StartRaumplaner()
    {
        _uiManager.CloseEmailArthur();
        _uiManager.OpenBrowser();
        _uiManager.OpenRaumplaner();
        _tabManager.ShowRaumplanerTab();
    }
    //activated when 'Submit' button is clicked
    public void RaumplanerOneDone()
    {
        dragBlocker.SetActive(true);
    }

    // activated when link on to do list is pressed
    public void StartVerkaufsportal()
    {
        _furnitureTracker.SellFurniture();
        _uiManager.OpenBrowser();
        _uiManager.OpenVerkaufsportal();
        _tabManager.ShowVerkaufsportalTab();
    }
    // activated when 'Post' button is clicked
    public void VerkaufsportalDone()
    {
        _adChecker.CheckIfSortedCorrectly();
        if (_adChecker.correctlySorted)
        {
            StartCoroutine(_uiManager.ShowingPopUpNewEmail());
        }
    }

    // activated when link in second email from Arthur is clicked
    public void StartRaumplanerAgain()
    {
        dragBlocker.SetActive(false);
        _furnitureTracker.ResetPosition();
        _uiManager.CloseNewEmailArthur();
        _uiManager.OpenBrowser();
        _tabManager.PutRaumplanerOnFront();
        StartCoroutine(HauntingInAction());
    }
    // manages Barty's behaviour upon reopening the Raumplaner
    IEnumerator HauntingInAction()
    {
        isBartyActive = true;
        _mouseBehaviour.enabled = true;
        StartCoroutine(_mouseBehaviour.BartyActivity());

        yield return new WaitForSeconds(45);

        _mouseBehaviour.fakeCursor.SetActive(false);
        _mouseBehaviour.enabled = false;
        Cursor.visible = true;
        _uiManager.ShowErrorMessageIcon();
    }

    // shows error instead of Verkaufsportal after the haunt
    public void OpenVerkaufsportalError()
    {
        if (isBartyActive)
        {
            _uiManager.CloseVerkaufsportal();
            _uiManager.ShowErrorMessage();
            _tabManager.HideRaumplanerTab();
            _uiManager.CloseRaumplaner();
            isBartyActive = false;
        }
        else
        {
            _tabManager.PutVerkaufsportalOnFront();
        }
    }

    // opens the Geisterscanner website when ad/pop-up is clicked
    public void ClickOnGeisterscannerAd()
    {
        _uiManager.OpenGeisterscannerWebsite();
        _tabManager.ShowGeisterscannerTab();
        _tabManager.HideRaumplanerTab();
    }

    public void DownloadGeisterscanner()
    {
        // Programmicon anzeigen
    }
}