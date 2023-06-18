using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // this script checks which button was pressed during the medium match
    // attached to each answer button

    private MediumMatch _mediumMatch;
    private Button button;

    void Start()
    {
        _mediumMatch = FindObjectOfType<MediumMatch>();
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ChoseAnswer);
    }

    // checks which tag the pressed button had
    // tag is assigned in MediumMatch script
    public void ChoseAnswer()
    {
        if (this.gameObject.tag == "Witch")
        {
            _mediumMatch.witchScore++;
        }
        if (this.gameObject.tag == "Hippie")
        {
            _mediumMatch.hippieScore++;
        }
        if (this.gameObject.tag == "Cyber")
        {
            _mediumMatch.cyberScore++;
        }

        if (_mediumMatch.currentQuestion < 4)
        {
            _mediumMatch.currentQuestion++;
            _mediumMatch.ShowNextQuestion();
        }
        if (_mediumMatch.currentQuestion == 4)
        {
            _mediumMatch.CheckForTie();
        }
        if (_mediumMatch.currentQuestion == 5)
        {
            _mediumMatch.CheckScore();
        }
    }
}
