using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject raumplaner;
    [SerializeField] private GameObject verkaufsportal;
    [SerializeField] private GameObject emailArthur;
    [SerializeField] private GameObject documentFolder;
    [SerializeField] private GameObject toDoListe;

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

    public void openEmailArthur()
    {
        emailArthur.SetActive(true);
    }
}
