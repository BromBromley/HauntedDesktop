using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    // this script manages which tabs are visible and puts them on front when clicked
    // attached to 00_Tabs

    [SerializeField] GameObject artikelVorbesitzer;
    [SerializeField] GameObject raumplaner;
    [SerializeField] GameObject verkaufsportal;
    [SerializeField] GameObject geisterscanner;
    [SerializeField] GameObject boogle;
    [SerializeField] GameObject medien;

    [SerializeField] GameObject tabArtikelVorbesitzer;
    [SerializeField] GameObject tabRaumplaner;
    [SerializeField] GameObject tabVerkaufsportal;
    [SerializeField] GameObject tabGeisterscanner;
    [SerializeField] GameObject tabBoogle;
    [SerializeField] GameObject tabMedien;

    void Start()
    {
        tabArtikelVorbesitzer.SetActive(false);
        tabRaumplaner.SetActive(false);
        tabVerkaufsportal.SetActive(false);
        tabGeisterscanner.SetActive(false);
        tabBoogle.SetActive(false);
        tabMedien.SetActive(false);
    }

    // makes the tabs visible when GameManager calls the method
    public void ShowArtikelTab()
    {
        tabArtikelVorbesitzer.SetActive(true);
    }

    public void ShowRaumplanerTab()
    {
        tabRaumplaner.SetActive(true);
    }

    public void ShowVerkaufsportalTab()
    {
        tabVerkaufsportal.SetActive(true);
    }
    
    public void ShowGeisterscannerTab()
    {
        tabGeisterscanner.SetActive(true);
    }

    public void ShowBoogleTab()
    {
        tabBoogle.SetActive(true);
    }

    public void ShowMedienTab()
    {
        tabMedien.SetActive(true);
    }

    public void HideRaumplanerTab()
    {
        tabRaumplaner.SetActive(false);
        // show some weird glitchy thing
    }
    
    public void HideVerkaufsportalTab()
    {
        tabVerkaufsportal.SetActive(false);
    }

    //  whatever tab has been pressed on front
    public void PutArtikelOnFront()
    {
        artikelVorbesitzer.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutRaumplanerOnFront()
    {
        raumplaner.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutVerkaufsportalOnFront()
    {
        verkaufsportal.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutGeisterscannerOnFront()
    {
        geisterscanner.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutBoogleOnFront()
    {
        boogle.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void PutMedienOnFront()
    {
        medien.GetComponent<RectTransform>().SetAsLastSibling();
    }
}
