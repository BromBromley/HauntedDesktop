using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject finalAvatar1;
    public GameObject finalAvatar2;
    public GameObject finalAvatar3;
    public GameObject finalAvatar4;
    public GameObject finalAvatar5;
    public GameObject finalAvatar6;
    public GameObject panel;
    public GameObject signInButton;

    public GameObject chooseAvatarButton;

    [SerializeField] private GameObject shutDownPopUp;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject home;

    [SerializeField] Texture2D planchette;

    void Start()
    {
       finalAvatar1.SetActive(false);
       finalAvatar2.SetActive(false);
       finalAvatar3.SetActive(false);
       finalAvatar4.SetActive(false);
       finalAvatar5.SetActive(false);
       finalAvatar6.SetActive(false);

       panel.SetActive(false);
       chooseAvatarButton.SetActive(false);
       shutDownPopUp.SetActive(false);
       settings.SetActive(false);
       home.SetActive(false);
       signInButton.SetActive(false);

       Cursor.SetCursor(planchette, Vector2.zero, CursorMode.Auto);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
