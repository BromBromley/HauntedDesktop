using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSelection : MonoBehaviour
{
    // this script handles the medium selection
    // attached to 06_Medien

    [SerializeField] private GameObject mediumMatch;
    [SerializeField] private GameObject mediumSelection;
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private GameObject communicationScreen;

    void Awake()
    {
        mediumSelection.SetActive(false);
        errorMessage.SetActive(false);
        mediumMatch.SetActive(true);
    }

    public void OpenSelection()
    {
        mediumMatch.SetActive(false);
        mediumSelection.SetActive(true);
    }

    public void OpenErrorMessage()
    {
        errorMessage.SetActive(true);
    }

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
