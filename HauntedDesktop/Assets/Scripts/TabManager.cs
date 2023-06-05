using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] GameObject artikelVorbesitzer;
    [SerializeField] GameObject raumplaner;
    [SerializeField] GameObject verkaufsportal;
    [SerializeField] GameObject geisterscanner;
    [SerializeField] GameObject boogle;
    [SerializeField] GameObject medien;

    public void PutArtikelOnFront()
    {
        artikelVorbesitzer.SetActive(true);
        artikelVorbesitzer.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutRaumplanerOnFront()
    {
        raumplaner.SetActive(true);
        raumplaner.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutVerkaufsportalOnFront()
    {
        verkaufsportal.SetActive(true);
        verkaufsportal.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutGeisterscannerOnFront()
    {
        geisterscanner.SetActive(true);
        geisterscanner.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutBoogleOnFront()
    {
        boogle.SetActive(true);
        boogle.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutMedienOnFront()
    {
        medien.SetActive(true);
        medien.GetComponent<RectTransform>().SetAsLastSibling();
    }
}
