using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // this script connects all other managers
    // functions are (mostly) written in chronological order 

    [SerializeField] private GameObject dragBlocker;
    private UIManager _uiManager;
    private BrowserManager _browserManager;
    private EmailManager _emailManager;
    private FurnitureTracker _furnitureTracker;
    private AdChecker _adChecker;
    private GhostScanner _ghostScanner;
    private MediumSelection _mediumSelection;
    private CommunicationPhase _communicationPhase;
    private MouseBehaviour _mouseBehaviour;

    public bool isBartyActive;

    //public Texture2D planchette;

    void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _browserManager = FindObjectOfType<BrowserManager>();
        _emailManager = FindObjectOfType<EmailManager>();
        _furnitureTracker = GetComponent<FurnitureTracker>();
        _adChecker = GetComponent<AdChecker>();
        _ghostScanner = FindObjectOfType<GhostScanner>();
        _mediumSelection = FindObjectOfType<MediumSelection>();
        _communicationPhase = FindObjectOfType<CommunicationPhase>();
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
        _browserManager.OpenBrowser();
        _uiManager.OpenArticleReginald();
        _browserManager.ShowArtikelTab();
        _browserManager.PutArtikelOnFront();
    }

    // activated when link in email is clicked
    public void StartRaumplaner()
    {
        _browserManager.OpenBrowser();
        _uiManager.OpenRaumplaner();
        _browserManager.ShowRaumplanerTab();
        _browserManager.PutRaumplanerOnFront();
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
        _browserManager.OpenBrowser();
        _uiManager.OpenVerkaufsportal();
        _browserManager.ShowVerkaufsportalTab();
        _browserManager.PutVerkaufsportalOnFront();
    }

    // activated when 'Post' button is clicked
    public void VerkaufsportalDone()
    {
        _adChecker.CheckIfSortedCorrectly();
        if (_adChecker.correctlySorted)
        {
            StartCoroutine(_uiManager.ShowingPopUpArthur());
            _emailManager.ShowNewEmailArthurTab();
            //_emailManager.ShowNoEmail();
            // show checkmark
        }
    }

    // activated when link in second email from Arthur is clicked
    public void StartRaumplanerAgain()
    {
        dragBlocker.SetActive(false);
        _furnitureTracker.ResetPosition();
        _browserManager.OpenBrowser();
        _browserManager.PutRaumplanerOnFront();
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
        _browserManager.OpenBrowser();
        _uiManager.OpenVerkaufsportal();
        _uiManager.OpenVerkaufsportalAfterError();
    }

    // opens the Geisterscanner website when ad is clicked
    public void ClickOnGeisterscannerAd()
    {
        _uiManager.OpenGeisterscannerWebsite();
        // put on top?
        _browserManager.ShowGeisterscannerTab();
        _browserManager.HideRaumplanerTab();
    }

    // opens Geisterscanner program
    public void DownloadGeisterscanner()
    {
        _uiManager.iconGeisterscanner.SetActive(true);
        _uiManager.OpenGeisterscannerApp();
        _browserManager.CloseBrowser();
    }

    public void StartGhostScan()
    {
        _ghostScanner.StartScanning();
    }

    // shows Boogle after Geisterscanner suggested it
    public void StartBoogleSearch()
    {
        _browserManager.OpenBrowser();
        _uiManager.OpenBoogleSearch();
        _browserManager.ShowBoogleTab();
        _browserManager.PutBoogleOnFront();
    }

    // opens MediumMatch when ad is clicked
    public void StartMediumMatch()
    {
        _uiManager.OpenMediumWebsite();
        _browserManager.ShowMedienTab();
        _browserManager.PutMedienOnFront();
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
        _communicationPhase.StartConversation();
    }
}