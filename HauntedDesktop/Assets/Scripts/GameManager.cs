using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // this script connects all other managers
    // functions are (mostly) written in chronological order 
    
    [SerializeField] private GameObject dragBlocker;
    [SerializeField] private TMP_Text nameFamilyTree;
    [SerializeField] private TMP_Text nameInheritance;
    private string displayedName;
    private AudioManager _audioManager;
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
    
    //for name Transfer 
    public string display_player_name;

    [SerializeField] Texture2D planchette;

    void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
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
        display_player_name = NameTransfer.nameInput;      
   }

    void Start()
    {
        Cursor.SetCursor(planchette, Vector2.zero, CursorMode.Auto);
        displayedName = PlayerPrefs.GetString("playerName");
        nameFamilyTree.text = displayedName;
        nameInheritance.text = displayedName;
    }

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
        _uiManager.feedbackRaumplaner.SetActive(true);
    }

    // activated when link on to do list is pressed
    public void StartVerkaufsportal()
    {
        _furnitureTracker.SellFurniture();
        _browserManager.OpenBrowser();
        _uiManager.OpenVerkaufsportal();
        _browserManager.ShowVerkaufsportalTab();
        _browserManager.PutVerkaufsportalOnFront();
        _uiManager.feedbackRaumplaner.SetActive(false);
    }

    // activated when 'Post' button is clicked
    public void VerkaufsportalDone()
    {
        _adChecker.CheckIfSortedCorrectly();
        if (_adChecker.correctlySorted)
        {
            StartCoroutine(_uiManager.ShowingPopUpArthur());
            _emailManager.ShowNewEmailArthurTab();
            _emailManager.ShowNotificationArthur();
            _uiManager.feedbackEbooh.SetActive(true);
            _adChecker.postButton.SetActive(false);
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

        isBartyActive = false;
        _mouseBehaviour.HideFakeCursor();
        _mouseBehaviour.enabled = false;
        StartCoroutine(_uiManager.ShowingPopUpError());
        _emailManager.ShowEmailErrorTab();
        _emailManager.ShowNotificationError();
        _browserManager.blocker.SetActive(false);
    }

    public void ClosingBrowser()
    {
        if (isBartyActive)
        {
            _browserManager.CloseBrowser();
            StartCoroutine(OpenBrowserAgain());
        }
        else 
        {
            _browserManager.CloseBrowser();
        }
    }

    IEnumerator OpenBrowserAgain()
    {
        yield return new WaitForSeconds(2);
        _browserManager.OpenBrowser();
        _browserManager.blocker.SetActive(true);
    }

    public void VerkaufsportalAfterError()
    {
        _browserManager.OpenBrowser();
        _browserManager.PutVerkaufsportalOnFront();
        _browserManager.HideRaumplanerTab();
        _uiManager.feedbackEbooh.SetActive(false);
        _adChecker.ResetAdChecker();
        _adChecker.postButton.SetActive(true);
        _furnitureTracker.ResetAdPosition();
        StartCoroutine(HauntingRoundTwo());
    }

    // manages Barty's behaviour upon reopening ebooh
    IEnumerator HauntingRoundTwo()
    {
        isBartyActive = true;
        _mouseBehaviour.enabled = true;
        StartCoroutine(_mouseBehaviour.SecondBartyActivity());

        yield return new WaitForSeconds(25);

        isBartyActive = false;
        _mouseBehaviour.HideFakeCursor();
        _mouseBehaviour.enabled = false;
        _uiManager.ShowGeisterscannerAd();
        _browserManager.blocker.SetActive(false);
    }

    // opens the Geisterscanner website when ad is clicked
    public void ClickOnGeisterscannerAd()
    {
        _uiManager.OpenGeisterscannerWebsite();
        _browserManager.PutGeisterscannerOnFront();
        _browserManager.ShowGeisterscannerTab();
        _browserManager.HideVerkaufsportalTab();
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

    // starts the communication phase with barty
    public void StartCommunicationBarty()
    {
        _communicationPhase.StartConversation();
        _mediumSelection.OpenCommunication();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}