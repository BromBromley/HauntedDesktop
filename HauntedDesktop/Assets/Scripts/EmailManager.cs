using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    // this script manages which emails are visible
    // attached to [GameManager]

    [SerializeField] GameObject emails;
    
    [SerializeField] GameObject emailKaty;
    [SerializeField] GameObject emailArthur;
    [SerializeField] GameObject newEmailArthur;
    [SerializeField] GameObject emailError;

    [SerializeField] GameObject tabNewEmailArthur;
    [SerializeField] GameObject tabEmailError;

    [SerializeField] GameObject unreadNotificationKaty;
    [SerializeField] GameObject unreadNotificationArthur;
    [SerializeField] GameObject unreadNotificationNewArthur;
    [SerializeField] GameObject unreadNotificationError;

    void Start()
    {
        emails.SetActive(false);
        tabNewEmailArthur.SetActive(false);
        tabEmailError.SetActive(false);
        unreadNotificationKaty.SetActive(true);
        unreadNotificationArthur.SetActive(true);
        unreadNotificationNewArthur.SetActive(false);
        unreadNotificationError.SetActive(false);
        ShowNoEmail();
    }

    public void OpenEmails()
    {
        emails.SetActive(true);
        ShowNoEmail();
    }

    public void CloseEmails()
    {
        ShowNoEmail();
        emails.SetActive(false);
    }

    // hides all emails, but not their tabs
    public void ShowNoEmail()
    {
        emailKaty.SetActive(false);
        emailArthur.SetActive(false);
        newEmailArthur.SetActive(false);
        emailError.SetActive(false);
    }

    // makes the tabs to emails visible when unlocked in game
    // called by GameManager
    public void ShowNewEmailArthurTab()
    {
        tabNewEmailArthur.SetActive(true);
    }

    public void ShowEmailErrorTab()
    {
        tabEmailError.SetActive(true);
    }

    // shows the little unread signs on the email tabs

    public void ClickedOnEmailKaty()
    {
        StartCoroutine(ShowingNotificationKaty());
    }

    IEnumerator ShowingNotificationKaty()
    {
        yield return new WaitForSeconds(2);
        unreadNotificationKaty.SetActive(false);
    }

    public void ClickedOnEmailArthur()
    {
        StartCoroutine(ShowingNotificationArthur());
    }

    IEnumerator ShowingNotificationArthur()
    {
        yield return new WaitForSeconds(2);
        unreadNotificationArthur.SetActive(false);
    }

    public void ShowNotificationArthur()
    {
        unreadNotificationNewArthur.SetActive(true);
    }

    public void ClickedOnNewEmailArthur()
    {
        StartCoroutine(ShowingNotificationNewArthur());
    }

    IEnumerator ShowingNotificationNewArthur()
    {
        yield return new WaitForSeconds(2);
        unreadNotificationNewArthur.SetActive(false);
    }

    public void ShowNotificationError()
    {
        unreadNotificationError.SetActive(true);
    }

    public void ClickedOnEmailError()
    {
        StartCoroutine(ShowingNotificationError());
    }

    IEnumerator ShowingNotificationError()
    {
        yield return new WaitForSeconds(2);
        unreadNotificationError.SetActive(false);
    }

    // puts whatever email has been clicked on top
    public void PutEmailKatyOnTop()
    {
        emailKaty.SetActive(true);
        emailArthur.SetActive(false);
        newEmailArthur.SetActive(false);
        emailError.SetActive(false);
    }

    public void PutEmailArthurOnTop()
    {
        emailKaty.SetActive(false);
        emailArthur.SetActive(true);
        newEmailArthur.SetActive(false);
        emailError.SetActive(false);
    }

    public void PutNewEmailArthurOnTop()
    {
        emailKaty.SetActive(false);
        emailArthur.SetActive(false);
        newEmailArthur.SetActive(true);
        emailError.SetActive(false);
    }

    public void PutEmailErrorOnTop()
    {
        emailKaty.SetActive(false);
        emailArthur.SetActive(false);
        newEmailArthur.SetActive(false);
        emailError.SetActive(true);
    }
}
