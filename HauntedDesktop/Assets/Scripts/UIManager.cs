using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // this script manages the status of all UI objects, functions are called by the Game Manager
    // attached to [UserInterface]

    [SerializeField] private GameObject documentFolder;
    [SerializeField] private GameObject toDoListe;
    [SerializeField] private GameObject raumplaner;
    [SerializeField] private GameObject verkaufsportal;
    [SerializeField] private GameObject emailArthur;
    [SerializeField] private GameObject popUpNewEmail;
    [SerializeField] private GameObject newEmailArthur;
    private void Start() 
    {
        documentFolder.SetActive(false);
        toDoListe.SetActive(false); 
        raumplaner.SetActive(false);
        //verkaufsportal.SetActive(false);
        emailArthur.SetActive(false);
        popUpNewEmail.SetActive(false);
        newEmailArthur.SetActive(false);
    }

    public void openDocuments()
    {
        documentFolder.SetActive(true);
    }

    public void openToDos()
    {
        toDoListe.SetActive(true);
    }

    public void openRaumplaner()
    {
        raumplaner.SetActive(true);
        documentFolder.SetActive(false);
    }
    public void closeRaumplaner()
    {
        raumplaner.SetActive(false);
    }

    public void openVerkaufsportal()
    {
        verkaufsportal.SetActive(true);
    }

    public void closeVerkaufsportal()
    {
        verkaufsportal.SetActive(false);
    }

    public void openEmailArthur()
    {
        emailArthur.SetActive(true);
    }

    public IEnumerator showingPopUpNewEmail()
    {
        popUpNewEmail.SetActive(true);

        yield return new WaitForSeconds(5);

        popUpNewEmail.SetActive(false);
    }

    public void openNewEmailArthur()
    {
        newEmailArthur.SetActive(true);
    }
}
