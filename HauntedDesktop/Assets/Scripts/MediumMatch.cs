using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MediumMatch : MonoBehaviour
{
    // this script manages the questions of the medium match and scores them
    // attached to [GameManager]

    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject toSelection;
    TMP_Text textButton1;
    TMP_Text textButton2;
    TMP_Text textButton3;
    public TMP_Text resultsText;
    public TMP_Text displayedQuestion;

    public int witchScore;
    public int hippieScore;
    public int cyberScore;
    private int resultsInt;
    private bool noTie = true;

    public int currentQuestion = 0;

    string[] questions = new string[5]; //war public?
    string[] witchAnswers = new string[5];
    string[] hippieAnswers = new string[5];
    string[] cyberAnswers = new string[5];
    string[] tieAnswers = new string[5];
    string[] results = new string[3];

    void Awake()
    {
        textButton1 = button1.GetComponentInChildren<TMP_Text>();
        textButton2 = button2.GetComponentInChildren<TMP_Text>();
        textButton3 = button3.GetComponentInChildren<TMP_Text>();
        resultsText = resultsText.GetComponent<TMP_Text>();
        displayedQuestion = displayedQuestion.GetComponent<TMP_Text>();

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        toSelection.SetActive(false);

        questions[0] = "Which trait describes you?";
        questions[1] = "What are your favourite colours?";
        questions[2] = "How do you spend your free time?";
        questions[3] = "What are you afraid of?";
        questions[4] = "What should the medium help you with?";

        witchAnswers[0] = "slyness";
        witchAnswers[1] = "pitch black and blood red";
        witchAnswers[2] = "cabin in the woods with my cat";
        witchAnswers[3] = "darkness";
        witchAnswers[4] = "exorcism";

        hippieAnswers[0] = "impartiality";
        hippieAnswers[1] = "avocado green andsunshine yellow";
        hippieAnswers[2] = "yoga retreat";
        hippieAnswers[3] = "loneliness";
        hippieAnswers[4] = "supernatural conversation";

        cyberAnswers[0] = "logic";
        cyberAnswers[1] = "electric violet and smart green";
        cyberAnswers[2] = "LAN party with my friends";
        cyberAnswers[3] = "loss of control";
        cyberAnswers[4] = "hardware problem";

        results[0] = "Pythia Alcina Cerridwen Feiticeira";
        results[1] = "Vyasa";
        results[2] = "Q";
    }

    public void ShowAnswerButtons()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }

    public void ShowNextQuestion()
    {
        if (currentQuestion == 0)
        {
            ShowFirstQuestion();
        }
        if (currentQuestion == 1)
        {
            ShowSecondQuestion();
        }
        if (currentQuestion == 2)
        {
            ShowThirdQuestion();
        }
        if (currentQuestion == 3)
        {
            ShowFourthQuestion();
        }
    }

    private void ShowFirstQuestion()
    {
        displayedQuestion.text = questions[0];
        textButton1.text = witchAnswers[0];
        button1.tag = "Witch";
        textButton2.text = hippieAnswers[0];
        button2.tag = "Hippie";
        textButton3.text = cyberAnswers[0];
        button3.tag = "Cyber";
    }

    private void ShowSecondQuestion()
    {
        displayedQuestion.text = questions[1];
        textButton1.text = hippieAnswers[1];
        button1.tag = "Hippie";
        textButton2.text = witchAnswers[1];
        button2.tag = "Witch";
        textButton3.text = cyberAnswers[1];
        button3.tag = "Cyber";
    }

    private void ShowThirdQuestion()
    {
        displayedQuestion.text = questions[2];
        textButton1.text = hippieAnswers[2];
        button1.tag = "Hippie";
        textButton2.text = cyberAnswers[2];
        button2.tag = "Cyber";
        textButton3.text = witchAnswers[2];
        button3.tag = "Witch";
    }

    private void ShowFourthQuestion()
    {
        displayedQuestion.text = questions[3];
        textButton1.text = witchAnswers[3];
        button1.tag = "Witch";
        textButton2.text = cyberAnswers[3];
        button2.tag = "Cyber";
        textButton3.text = hippieAnswers[3];
        button3.tag = "Hippie";
    }

    public void CheckForTie()
    {   
        if (witchScore == hippieScore && witchScore == cyberScore)
        {
            print("tie between all three");
            noTie = false;
            currentQuestion++;

            displayedQuestion.text = questions[4];
            textButton1.text = witchAnswers[4];
            button1.tag = "Witch";
            textButton2.text = hippieAnswers[4];
            button2.tag = "Hippie";
            textButton3.text = cyberAnswers[4];
            button3.tag = "Cyber";
        }
        else if (witchScore == hippieScore && witchScore > 0)
        {
            noTie = false;
            button2.SetActive(false);
            currentQuestion++;

            displayedQuestion.text = questions[4];
            textButton1.text = witchAnswers[4];
            button1.tag = "Witch";
            textButton3.text = hippieAnswers[4];
            button3.tag = "Hippie";
        }
        else if (hippieScore == cyberScore && hippieScore > 0)
        {
            noTie = false;
            button2.SetActive(false);
            currentQuestion++;

            displayedQuestion.text = questions[4];
            textButton1.text = hippieAnswers[4];
            button1.tag = "Hippie";
            textButton3.text = cyberAnswers[4];
            button3.tag = "Cyber";
        }
        else if (cyberScore == witchScore && cyberScore > 0)
        {
            noTie = false;
            button2.SetActive(false);
            currentQuestion++;

            displayedQuestion.text = questions[4];
            textButton1.text = cyberAnswers[4];
            button1.tag = "Cyber";
            textButton3.text = witchAnswers[4];
            button3.tag = "Witch";
        }

        if (noTie)
        {
            CheckScore();
        }
    }

    public void CheckScore()
    {
        if (witchScore > hippieScore && witchScore > cyberScore)
        {
            resultsInt = 0;
            ShowResults();
        }
        if (hippieScore > witchScore && hippieScore > cyberScore)
        {
            resultsInt = 1;
            ShowResults();
        }
        if (cyberScore > witchScore && cyberScore > hippieScore)
        {
            resultsInt = 2;
            ShowResults();
        }
    }

    private void ShowResults()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        displayedQuestion.text = "";
        resultsText.text = "Dir kann am besten " + results[resultsInt] + " helfen!";
        toSelection.SetActive(true);
    }

    public void StartAgain()
    {
        toSelection.SetActive(false);
        resultsText.text = "";
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        currentQuestion = 0;
        witchScore = 0;
        hippieScore = 0;
        cyberScore = 0;
        ShowFirstQuestion();
    }
}