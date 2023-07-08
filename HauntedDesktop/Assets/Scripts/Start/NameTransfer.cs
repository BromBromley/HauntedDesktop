using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameTransfer : MonoBehaviour
{
    // this script saves the name the player types in

    public static NameTransfer nameTransfer;
    public static string nameInput;
    [SerializeField] private GameObject inputField;
    [SerializeField] TMP_Text showName;

    public void StoreName()
    {
        nameInput = inputField.GetComponent<TMPro.TextMeshProUGUI>().text;
        PlayerPrefs.SetString("playerName", nameInput); 
        showName.text = nameInput;
    }
}