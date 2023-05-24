using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject raumplaner;
    [SerializeField] private GameObject verkaufsportal;
    [SerializeField] private GameObject emailArthur;

    public void openRaumplaner()
    {
        raumplaner.SetActive(true);
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
