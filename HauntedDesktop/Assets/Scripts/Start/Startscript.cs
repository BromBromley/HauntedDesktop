using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startscript : MonoBehaviour
{
    public GameObject finalAvatar1;
    public GameObject finalAvatar2;
    public GameObject finalAvatar3;
    public GameObject finalAvatar4;
    public GameObject finalAvatar5;
    public GameObject finalAvatar6;
    public GameObject panel;
    public GameObject startButton;

    public GameObject invisibleButton;

    [SerializeField] private GameObject shutDownPopUp;

    void Start()
    {
       finalAvatar1.SetActive(false);
       finalAvatar2.SetActive(false);
       finalAvatar3.SetActive(false);
       finalAvatar4.SetActive(false);
       finalAvatar5.SetActive(false);
       finalAvatar6.SetActive(false);

       panel.SetActive(false);
       invisibleButton.SetActive(false);
       shutDownPopUp.SetActive(false);
       startButton.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
