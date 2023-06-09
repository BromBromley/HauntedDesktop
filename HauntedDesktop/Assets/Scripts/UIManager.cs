using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // this script manages the status of all UI objects except for emails and browser
    // functions are called by GameManager
    // attached to [UserInterface]

    private AudioManager _audioManager;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject documentFolder;
    [SerializeField] private GameObject toDoListe;
    [SerializeField] private GameObject articleReginald;
    [SerializeField] private GameObject raumplaner;
    [SerializeField] private GameObject verkaufsportal;
    [SerializeField] private GameObject minigameLayout;
    [SerializeField] private GameObject emailArthur;
    [SerializeField] private GameObject popUpEmailArthur;
    [SerializeField] private GameObject popUpEmailError;
    [SerializeField] private GameObject adGeisterscanner;
    [SerializeField] private GameObject geisterscannerWebsite;
    [SerializeField] public GameObject iconGeisterscanner;
    [SerializeField] private GameObject geisterscannerApp;
    [SerializeField] private GameObject boogle;
    [SerializeField] private GameObject boogleSearch;
    [SerializeField] private GameObject boogleResults;
    [SerializeField] private GameObject bartyArticle;
    [SerializeField] private GameObject medienWebsite;
    [SerializeField] private GameObject documentFotoHall;
    [SerializeField] private GameObject documentErbschein;
    
    [SerializeField] private GameObject documentStammBaum;
    [SerializeField] private GameObject documentGrundriss;
    [SerializeField] private GameObject documentFotoFront;

    [SerializeField] private GameObject loadingIconBrowser;
    private float timeLoading;
    private Quaternion endRotation = new Quaternion(0, 0, 359, 0);

    public GameObject feedbackEbooh;
    public GameObject feedbackRaumplaner;

    private void Start() 
    {
        _audioManager = FindObjectOfType<AudioManager>();
        settings.SetActive(false);
        home.SetActive(false);
        documentFolder.SetActive(false);
        toDoListe.SetActive(false); 
        articleReginald.SetActive(false);
        raumplaner.SetActive(false);
        verkaufsportal.SetActive(false);
        popUpEmailArthur.SetActive(false);
        popUpEmailError.SetActive(false);
        adGeisterscanner.SetActive(false);
        geisterscannerWebsite.SetActive(false);
        iconGeisterscanner.SetActive(false);
        geisterscannerApp.SetActive(false);
        boogle.SetActive(false);
        boogleResults.SetActive(false);
        bartyArticle.SetActive(false);
        medienWebsite.SetActive(false);
        documentFotoHall.SetActive(false);
        documentStammBaum.SetActive(false);
        documentErbschein.SetActive(false);
        documentGrundriss.SetActive(false);
        documentFotoFront.SetActive(false);
        feedbackEbooh.SetActive(false);
        feedbackRaumplaner.SetActive(false);
        loadingIconBrowser.SetActive(false);
    }


    public void OpenDocuments()
    {
        documentFolder.SetActive(true);
    }

    public void OpenToDos()
    {
        toDoListe.SetActive(true);
    }

    public void OpenArticleReginald()
    {
        articleReginald.SetActive(true);
    }

    public void OpenRaumplaner()
    {
        raumplaner.SetActive(true);
        documentFolder.SetActive(false);
    }
    public void CloseRaumplaner()
    {
        raumplaner.SetActive(false);
    }

    public void OpenVerkaufsportal()
    {
        verkaufsportal.SetActive(true);
    }

    public void CloseVerkaufsportal()
    {
        verkaufsportal.SetActive(false);
    }

    public IEnumerator ShowingPopUpArthur()
    {
        yield return new WaitForSeconds(4);
        _audioManager.PlayNotificationSound();

        popUpEmailArthur.SetActive(true);

        yield return new WaitForSeconds(5);

        popUpEmailArthur.SetActive(false);
    }

    public IEnumerator ShowingPopUpError()
    {
        yield return new WaitForSeconds(3);

        popUpEmailError.SetActive(true);
        _audioManager.PlayNotificationSound();

        yield return new WaitForSeconds(5);

        popUpEmailError.SetActive(false);
    }

    public void ShowGeisterscannerAd()
    {
        adGeisterscanner.SetActive(true);
    }

    public void OpenGeisterscannerWebsite()
    {
        geisterscannerWebsite.SetActive(true);
    }

    public void OpenGeisterscannerApp()
    {
        geisterscannerApp.SetActive(true);
    }

    public void OpenBoogleSearch()
    {
        boogle.SetActive(true);
        boogleSearch.SetActive(true);
        boogleResults.SetActive(false);
    }

    public void StartBoogleSearch()
    {
        loadingIconBrowser.SetActive(true);
        StartCoroutine(StartSearch());
    }

    IEnumerator StartSearch()
    {
        while (true)
        {
            loadingIconBrowser.GetComponent<RectTransform>().transform.Rotate(0.0f, 0.0f, -5.0f, Space.Self); 
            timeLoading += 0.01f;
            if (timeLoading >= 1.5f)
            {
                boogleResults.SetActive(true);
                loadingIconBrowser.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }

    public void OpenMediumWebsite()
    {
        medienWebsite.SetActive(true);
    }
}
