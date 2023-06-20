using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSelection : MonoBehaviour
{
    // this script handles the medium selection
    // attached to [GameManager]

    [SerializeField] private GameObject mediumMatch;
    [SerializeField] private GameObject mediumSelection;
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private GameObject communicationScreen;
    [SerializeField] private GameObject overviewWitch;
    [SerializeField] private GameObject overviewHippie;
    [SerializeField] private GameObject overviewCyber;

    void Awake()
    {
        mediumSelection.SetActive(false);
        errorMessage.SetActive(false);
        communicationScreen.SetActive(false);
        mediumMatch.SetActive(true);
        overviewWitch.SetActive(false);
        overviewHippie.SetActive(false);
        overviewCyber.SetActive(false);
    }

    public void OpenSelection()
    {
        mediumMatch.SetActive(false);
        mediumSelection.SetActive(true);
    }

    // opens the confirmation screen for each medium
    public void ChooseWitch()
    {
        overviewWitch.SetActive(true);
    }

    public void ChooseHippie()
    {
        overviewHippie.SetActive(true);
    }

    public void ChooseCyber()
    {
        overviewCyber.SetActive(true);
    }

    // opens an error message if you select the witch or cyber
    public void OpenErrorMessage()
    {
        overviewWitch.SetActive(false);
        overviewCyber.SetActive(false);
        errorMessage.SetActive(true);
    }

    // brings you back to start the medium match again 
    // currently not used
    public void StartMatchAgain()
    {
        errorMessage.SetActive(false);
        mediumSelection.SetActive(false);
        mediumMatch.SetActive(true);
    }

    public void OpenCommunication()
    {
        mediumSelection.SetActive(false);
        communicationScreen.SetActive(true);
    }
}
