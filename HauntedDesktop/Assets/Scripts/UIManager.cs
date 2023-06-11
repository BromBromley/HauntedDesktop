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
    [SerializeField] private GameObject raumplaner;
    [SerializeField] private GameObject verkaufsportal;
    [SerializeField] private GameObject emailArthur;
    [SerializeField] private GameObject popUpNewEmail;
    [SerializeField] private GameObject newEmailArthur;
    [SerializeField] private GameObject icon_errorMessage;
    [SerializeField] public GameObject errorMessage;
    [SerializeField] private GameObject geisterscannerWebsite;
    [SerializeField] private GameObject geisterscannerApp;
    [SerializeField] private GameObject medienWebsite;

    private void Start() 
    {
        documentFolder.SetActive(false);
        emails.SetActive(false);
        toDoListe.SetActive(false); 
        browser.SetActive(false);
        raumplaner.SetActive(false);
        verkaufsportal.SetActive(false);
        emailArthur.SetActive(false);
        popUpNewEmail.SetActive(false);
        newEmailArthur.SetActive(false);
        icon_errorMessage.SetActive(false);
        errorMessage.SetActive(false);
        geisterscannerWebsite.SetActive(false);
        geisterscannerApp.SetActive(false);
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

    public IEnumerator ShowingPopUpNewEmail()
    {
        popUpNewEmail.SetActive(true);

        yield return new WaitForSeconds(5);

        popUpNewEmail.SetActive(false);
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

    public void ShowErrorMessageIcon()
    {
        icon_errorMessage.SetActive(true);
    }

    public void ShowErrorMessage()
    {
        verkaufsportal.SetActive(false);
        errorMessage.SetActive(true);
    }

    public void OpenGeisterscannerWebsite()
    {
        geisterscannerWebsite.SetActive(true);
    }
}
