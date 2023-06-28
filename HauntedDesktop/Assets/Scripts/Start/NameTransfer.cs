using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    public static string nameInput;
    public GameObject inputField;
    public GameObject textDisplay;



    public void StoreName()
    {
        nameInput = inputField.GetComponent<TMPro.TextMeshProUGUI>().text;
        textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = nameInput;
        PlayerPrefs.SetString("playerName", nameInput);
    }
}