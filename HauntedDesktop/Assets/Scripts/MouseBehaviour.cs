using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseBehaviour : MonoBehaviour
{
    // this script influences the mouse behavior during the second Raumplaner minigame
    // attached to [GameManager]

    [SerializeField] public GameObject fakeCursor;
    private Vector3 velocity = Vector3.zero;
    private Vector3 mousePosition;
    private float dragSpeed = 0.01f;
    private int timeActive = 0;
    private bool isBartyActive = false;

    void Awake() 
    {
        fakeCursor.SetActive(false);
    }

    void Update()
    {
        if (isBartyActive)
        {   
            mousePosition = Mouse.current.position.ReadValue();
            fakeCursor.transform.position = Vector3.SmoothDamp(fakeCursor.transform.position, mousePosition, ref velocity, dragSpeed);
            fakeCursor.transform.SetAsLastSibling();
            dragSpeed += 0.001f;
        }
    }

    public IEnumerator BartyActivity()
    {
        yield return new WaitForSeconds(5);

        ShowFakeCursor();

        timeActive = Random.Range(3, 8);
        yield return new WaitForSeconds(timeActive);

        HideFakeCursor();

        timeActive = Random.Range(10, 12);
        yield return new WaitForSeconds(timeActive);

        ShowFakeCursor();
        dragSpeed = 0.05f;

        timeActive = Random.Range(8, 13);
        yield return new WaitForSeconds(timeActive);

        HideFakeCursor();

        timeActive = Random.Range(5, 8);
        yield return new WaitForSeconds(timeActive);

        ShowFakeCursor();

        yield return null;
    }

    private void ShowFakeCursor()
    {
        Cursor.visible = false;
        fakeCursor.SetActive(true);
        isBartyActive = true;
    }

    public void HideFakeCursor()
    {
        Cursor.visible = true;
        fakeCursor.SetActive(false);
        isBartyActive = false;
    }
}
