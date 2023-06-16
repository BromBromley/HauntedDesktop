using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScanner : MonoBehaviour
{
    // this script manages the animations of the ghost scanner
    // attached to [GameManager]

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject loadingIcon;
    [SerializeField] private GameObject results;
    [SerializeField] private GameObject boogleLink;
    private float timeScanning;
    private Quaternion endRotation = new Quaternion(0, 0, 359, 0);

    void Start()
    {
        startButton.SetActive(true);
        loadingIcon.SetActive(false);
        results.SetActive(false);
        boogleLink.SetActive(false);
    }
    public void StartScanning()
    {
        startButton.SetActive(false);
        loadingIcon.SetActive(true);
        StartCoroutine(Scanning());
    }

    IEnumerator Scanning()
    {
        while (true)
        {
            loadingIcon.GetComponent<RectTransform>().transform.Rotate(0.0f, 0.0f, -5.0f, Space.Self); 
            timeScanning += 0.01f;
            if (timeScanning >= 5f)
            {
                FinishedScanning();
                yield break;
            }
            yield return null;
        }
    }

    private void FinishedScanning()
    {
        loadingIcon.SetActive(false);
        results.SetActive(true);
        boogleLink.SetActive(true);
    }
}
