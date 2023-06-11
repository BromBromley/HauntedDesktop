using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MediumMatch : MonoBehaviour
{
    // this script scores the answers of the medium match

    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] TMP_Text displayedQuestion;
    [SerializeField] TMP_Text textButton1;
    [SerializeField] TMP_Text textButton2;
    [SerializeField] TMP_Text textButton3;

    private int witchScore;
    private int hippieScore;
    private int cyberScore;
    private int highestScore;
    private bool noTie = true;

    string[] questions = new string[5];
    string[] witchAnswers = new string[5];
    string[] hippieAnswers = new string[5];
    string[] cyberAnswers = new string[5];
    string[] tieAnswers = new string[5];

    void Awake()
    {
        displayedQuestion = displayedQuestion.GetComponent<TMP_Text>();
        textButton1 = button1.GetComponentInChildren<TMP_Text>();
        textButton2 = button2.GetComponentInChildren<TMP_Text>();
        textButton3 = button3.GetComponentInChildren<TMP_Text>();

        /*button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);*/
    }

    public void AssignQuestions()
    {
        questions[0] = "Welche Eigenschaft schätzt du an dir?";
        questions[1] = "Was sind deine Lieblingsfarben?";
        questions[2] = "Wo verbringst du am liebsten deine Freizeit?";
        questions[3] = "Wovor hast du Angst?";
        questions[4] = "Womit soll das Medium dir helfen?";

        witchAnswers[0] = "Dunkelheit";
        witchAnswers[1] = "";
        witchAnswers[2] = "";
        witchAnswers[3] = "";
        witchAnswers[4] = "";

        hippieAnswers[0] = "Einsamkeit";
        hippieAnswers[1] = "";
        hippieAnswers[2] = "";
        hippieAnswers[3] = "";
        hippieAnswers[4] = "";

        cyberAnswers[0] = "Kontrollverlust";
        cyberAnswers[1] = "";
        cyberAnswers[2] = "";
        cyberAnswers[3] = "";
        cyberAnswers[4] = "";
    }

    public void ShowAnswerButtons()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }

    public void ShowFirstQuestion()
    {
        displayedQuestion.text = questions[0];
        textButton1.text = witchAnswers[0];
        textButton2.text = hippieAnswers[0];
        textButton3.text = cyberAnswers[0];
    }

    public void ChoseAnswer()
    {
        // if button was tagged 'witch' etc.?
    }

    public void CheckScore()
    {   
        if (witchScore == hippieScore && witchScore > 0)
        {
            noTie = false;
            // go to witch/hippie question
        }
        if (hippieScore == cyberScore && hippieScore > 0)
        {
            noTie = false;
            // go to hippie/cyber question
        }
        if (cyberScore == witchScore && cyberScore > 0)
        {
            noTie = false;
            // go to cyber/witch question
        }

        highestScore = witchScore;
        if (hippieScore > highestScore)
        {
            highestScore = hippieScore;
        }
        else if (cyberScore > highestScore)
        {
            highestScore = hippieScore;
        }

        if (noTie)
        {
            // show result 
        }
    }
}
