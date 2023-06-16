using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject dragBlocker;
    private UIManager _uiManager;
    private TabManager _tabManager;
    private EmailManager _emailManager;
    private FurnitureTracker _furnitureTracker;
    private AdChecker _adChecker;
    private GhostScanner _ghostScanner;
    private MediumSelection _mediumSelection;
    private MouseBehaviour _mouseBehaviour;

    public bool isBartyActive;

    //public Texture2D planchette;

    void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _tabManager = FindObjectOfType<TabManager>();
        _emailManager = FindObjectOfType<EmailManager>();
        _furnitureTracker = GetComponent<FurnitureTracker>();
        _adChecker = GetComponent<AdChecker>();
        _ghostScanner = FindObjectOfType<GhostScanner>();
        _mediumSelection = FindObjectOfType<MediumSelection>();
        _mouseBehaviour = GetComponent<MouseBehaviour>();
        _mouseBehaviour.enabled = false; 
        dragBlocker.SetActive(false);       
   }

    /*void Start()
    {
        Cursor.SetCursor(planchette, Vector2.zero, CursorMode.Auto);
    }*/

    // activated when link in Katy's email is clicked
    public void FindArticleReginald()
    {
        _uiManager.OpenBrowser();
        _uiManager.OpenArticleReginald();
        _tabManager.ShowArtikelTab();
        _tabManager.PutArtikelOnFront();
    }

    // activated when link in email is clicked
    public void StartRaumplaner()
    {
        //_uiManager.CloseEmailArthur();
        _uiManager.OpenBrowser();
        _uiManager.OpenRaumplaner();
        _tabManager.ShowRaumplanerTab();
        _tabManager.PutRaumplanerOnFront();
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
        _tabManager.PutVerkaufsportalOnFront();
    }
    // activated when 'Post' button is clicked
    public void VerkaufsportalDone()
    {
        _adChecker.CheckIfSortedCorrectly();
        if (_adChecker.correctlySorted)
        {
            StartCoroutine(_uiManager.ShowingPopUpArthur());
            _emailManager.ShowNewEmailArthurTab();
            _emailManager.ShowNoEmail();
            // show checkmark
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
        StartCoroutine(_uiManager.ShowingPopUpError());
        _emailManager.ShowEmailErrorTab();
        _emailManager.PutEmailErrorOnTop();
        _uiManager.OpenVerkaufsportalAfterError();
    }

    public void VerkaufsportalAfterError()
    {
        _uiManager.OpenBrowser();
        _uiManager.OpenVerkaufsportal();
        _uiManager.OpenVerkaufsportalAfterError();
    }

    // opens the Geisterscanner website when ad is clicked
    public void ClickOnGeisterscannerAd()
    {
        _uiManager.OpenGeisterscannerWebsite();
        // put on top?
        _tabManager.ShowGeisterscannerTab();
        _tabManager.HideRaumplanerTab();
    }

    // opens Geisterscanner program
    public void DownloadGeisterscanner()
    {
        _uiManager.iconGeisterscanner.SetActive(true);
        _uiManager.OpenGeisterscannerApp();
        _uiManager.CloseBrowser();
    }

    public void StartGhostScan()
    {
        _ghostScanner.StartScanning();
    }

    // shows Boogle after Geisterscanner suggested it
    public void StartBoogleSearch()
    {
        _uiManager.OpenBrowser();
        _uiManager.OpenBoogleSearch();
        _tabManager.ShowBoogleTab();
        _tabManager.PutBoogleOnFront();
    }

    // opens MediumMatch when ad is clicked
    public void StartMediumMatch()
    {
        _uiManager.OpenMediumWebsite();
        _tabManager.ShowMedienTab();
        _tabManager.PutMedienOnFront();
    }

    // checks which medium was chosen
    public void CheckMediumSelection()
    {
        if (_mediumSelection.gameObject.tag == "Witch" || _mediumSelection.gameObject.tag == "Cyber")
        {
            _mediumSelection.OpenErrorMessage();
        }
        if(_mediumSelection.gameObject.tag == "Hippie")
        {
            _mediumSelection.OpenCommunication();
            StartCommunicationBarty();
        }
    }

    // starts the communication phase with barty
    public void StartCommunicationBarty()
    {
        print("seance in session");
    }
}