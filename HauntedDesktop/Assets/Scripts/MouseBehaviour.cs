using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseBehaviour : MonoBehaviour
{
    // under construction
    // attached to [GameManager]

    //public bool isBartyActive; -> moved to GameManager
    /*private float speed = 5f;
    private Vector2 currentPosition;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float dampingSpeed = 0.03f;*/

    private void WarpingCursor()
    {
        /*currentPosition = Mouse.current.position;
        if (isBartyActive)
        {
            currentPosition += Vector2.left * speed * Time.deltaTime;
            Mouse.current.WarpCursorPosition(currentPosition);
        }*/
    }
}
