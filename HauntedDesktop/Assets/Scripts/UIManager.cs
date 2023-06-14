using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // this script manages the status of all UI objects, functions are called by the Game Manager
    // attached to [UserInterface]

    [SerializeField] private GameObject documentFolder;
    [SerializeField] private GameObject emails;
    [SerializeField] private GameObject toDoListe;
    [SerializeField] private GameObject browser;
    [SerializeField] private GameObject articleReginald;
    [SerializeField] private GameObject raumplaner;
    [SerializeField] private GameObject verkaufsportal;
    [SerializeField] private GameObject minigameLayout;
    [SerializeField] private GameObject emailArthur;
    [SerializeField] private GameObject popUpEmailArthur;
    [SerializeField] private GameObject popUpEmailError;
    [SerializeField] private GameObject newEmailArthur;
    [SerializeField] public GameObject emailError;
    [SerializeField] private GameObject adGeisterscanner;
    [SerializeField] private GameObject geisterscannerWebsite;
    [SerializeField] public GameObject iconGeisterscanner;
    [SerializeField] private GameObject geisterscannerApp;
    [SerializeField] private GameObject boogle;
    [SerializeField] private GameObject boogleSearch;
    [SerializeField] private GameObject boogleResults;
    [SerializeField] private GameObject medienWebsite;

    private void Start() 
    {
        documentFolder.SetActive(false);
        emails.SetActive(false);
        toDoListe.SetActive(false); 
        browser.SetActive(false);
        articleReginald.SetActive(false);
        raumplaner.SetActive(false);
        verkaufsportal.SetActive(false);
        popUpEmailArthur.SetActive(false);
        popUpEmailError.SetActive(false);
        newEmailArthur.SetActive(false);
        emailError.SetActive(false);
        adGeisterscanner.SetActive(false);
        geisterscannerWebsite.SetActive(false);
        iconGeisterscanner.SetActive(false);
        geisterscannerApp.SetActive(false);
        boogle.SetActive(false);
        boogleResults.SetActive(false);
        medienWebsite.SetActive(false);
    }


    public void OpenDocuments()
    {
        documentFolder.SetActive(true);
    }

    public void OpenEmails()
    {
        emails.SetActive(true);
    }

    public void OpenToDos()
    {
        toDoListe.SetActive(true);
    }

    public void OpenBrowser()
    {
        browser.SetActive(true);
    }

    public void CloseBrowser()
    {
        browser.SetActive(false);
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

    public void OpenEmailArthur()
    {
        emails.SetActive(true);
        emailArthur.SetActive(true);
    }

    public void CloseEmailArthur()
    {
        emailArthur.SetActive(false);
        emails.SetActive(false);
    }

    public IEnumerator ShowingPopUpArthur()
    {
        yield return new WaitForSeconds(4);

        popUpEmailArthur.SetActive(true);

        yield return new WaitForSeconds(5);

        popUpEmailArthur.SetActive(false);
    }

    public void OpenNewEmailArthur()
    {
        emails.SetActive(true);
        newEmailArthur.SetActive(true);
    }

    public void CloseNewEmailArthur()
    {
        newEmailArthur.SetActive(false);
        emails.SetActive(false);
    }

    public IEnumerator ShowingPopUpError()
    {
        yield return new WaitForSeconds(3);

        popUpEmailError.SetActive(true);

        yield return new WaitForSeconds(5);

        popUpEmailError.SetActive(false);
    }

    public void OpenEmailError()
    {
        emailError.SetActive(true);
    }

    public void OpenVerkaufsportalAfterError()
    {
        minigameLayout.SetActive(false);
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
        StartCoroutine(StartSearch());
    }

    IEnumerator StartSearch()
    {
        yield return new WaitForSeconds(2);
        boogleResults.SetActive(true);
    }

    public void OpenMediumWebsite()
    {
        medienWebsite.SetActive(true);
    }
}
