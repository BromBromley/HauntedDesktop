using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CommunicationPhase : MonoBehaviour
{
    // this script manages the conversation with Barty
    // attached to [GameManager]

    [SerializeField] GameObject textMedium;

    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;
    [SerializeField] private Button buttonMiddle;
    
    TMP_Text textAnswerLeft;
    TMP_Text textAnswerRight;
    TMP_Text textAnswerMiddle;
    public TMP_Text textBarty;

    [SerializeField] private int sadnessScore;
    [SerializeField] private int angerScore;
    [SerializeField] private int currentDialogue;

    [SerializeField] private GameObject angerLevel;
    [SerializeField] private GameObject sadnessLevel;

    Vector3 scaleChange = new Vector3(0.0f, 0.1f, 0.0f);

    private bool doingA;
    private bool doingB;
    private bool doingC;
    private bool doingC0;
    private bool doingX;
    private bool doingD;

    private bool completedA;
    private bool completedB;
    private bool completedC;
    private bool completedC0;

    string[] bartyA = new string[4];
    string[] answerLeftA = new string[3];
    string[] answerRightA = new string[3];

    string[] bartyB = new string[3];
    string[] answerLeftB = new string[2];
    string[] answerRightB = new string[2];

    string[] bartyC = new string[3];
    string[] answerLeftC = new string[2];
    string[] answerRightC = new string[2];

    string[] bartyC0 = new string[3];

    string[] bartyX = new string[3];
    string[] answerLeftX = new string[2];
    string[] answerRightX = new string[2];
 
    string[] bartyD = new string[6];
    string[] answerLeftD = new string[6];
    string[] answerRightD = new string[6];

    [SerializeField] private GameObject endscreen;
    [SerializeField] private GameObject goodEndingText;
    [SerializeField] private GameObject badEndingText;

    void Start()
    {
        buttonLeft = buttonLeft.GetComponent<Button>();
        buttonRight = buttonRight.GetComponent<Button>();
        buttonMiddle = buttonMiddle.GetComponent<Button>();
        textAnswerLeft = buttonLeft.GetComponentInChildren<TMP_Text>();
        textAnswerRight = buttonRight.GetComponentInChildren<TMP_Text>();
        textAnswerMiddle = buttonMiddle.GetComponentInChildren<TMP_Text>();

        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
        buttonMiddle.gameObject.SetActive(false);

        textMedium.SetActive(true);

        textBarty = textBarty.GetComponent<TMP_Text>();
        textBarty.text = "";

        endscreen.SetActive(false);
    }

    private void AssignArrays()
    {
        bartyA[0] = "It has been a long time since someone has spoken to me.";
        bartyA[1] = "Yes.";
        bartyA[2] = "It feels like a nightmare you cannot wake up from.";
        bartyA[3] = "I don't know how.";
        answerLeftA[0] = "Because you are a ghost.";
        answerLeftA[1] = "I bet it's kind of cool to be a ghost.";
        answerLeftA[2] = "Why don't you just leave?";
        answerRightA[0] = "You must be lonely.";
        answerRightA[1] = "It must be horrible to be a ghost.";
        answerRightA[2] = "You can't leave?";

        bartyB[0] = "If you want to know who I am, try to find out.";
        bartyB[1] = "Yes.";
        bartyB[2] = "I am Barty, Reginald is my brother.";
        answerLeftB[0] = "Did you die here?";
        answerLeftB[1] = "Are you Reginald Montgomery?";
        answerRightB[0] = "Do you live here?";
        answerRightB[1] = "Are you Bartholomew Montgomery?";

        bartyC[0] = "What are you thinking of?";
        bartyC[1] = "That's true. My brother keeps everything in order.";
        bartyC[2] = "What?! What happened to my brother?";
        answerLeftC[0] = "Since you became a ghost, nothing changed in the house.";
        answerLeftC[1] = "But this is my house now.";
        answerRightC[0] = "You don't like it when things are rearranged in the house.";
        answerRightC[1] = "Your brother isn't here anymore.";

        bartyC0[0] = "What do you mean?";
        bartyC0[1] = "Yes.";
        bartyC0[2] = "Are you crazy?! You don't touch anything in the house!!";

        bartyX[0] = "I do not want to talk to you anymore!";
        bartyX[1] = "Why should I believe you?";
        bartyX[2] = "And I thought you were an intruder.";
        answerLeftX[0] = "Don't be mad at me, I'm just trying to help you!";
        answerLeftX[1] = "You are my great great cousin, I'm part of your family.";
        answerRightX[0] = "I don't want to harm you in any way!";
        answerRightX[1] = "We are related, I am the one who inherits this house.";

        bartyD[0] = "Reginald dead? This can't be true!";
        bartyD[1] = "How old was he?";
        bartyD[2] = "This old... That means that I have been dead for 94 years now.";
        bartyD[3] = "It all changed so much although I tried so hard to preserve everthing.";
        bartyD[4] = "But I have to take care of everything.";
        bartyD[5] = "You mean that I can just leave?";
        answerLeftD[0] = "We all have to die one day.";
        answerLeftD[1] = "102 years old, he was very lonely.";
        answerLeftD[2] = "Yes, you should leave.";
        answerLeftD[3] = "Change isn't bad.";
        answerLeftD[4] = "You don't.";
        answerLeftD[5] = "You could have left this place the whole time.";
        answerRightD[0] = "He was very old.";
        answerRightD[1] = "102 years old, a long and fulfilled life.";
        answerRightD[2] = "Yes, I think it is time for you to let go.";
        answerRightD[3] = "I can understand that you are afraid.";
        answerRightD[4] = "Now I am here, I can take care.";
        answerRightD[5] = "Yes, go to Reginald";
    }

    public void StartConversation()
    {
        AssignArrays();
        ShowMiddleButton();
        buttonMiddle.onClick.AddListener(BartyAppears);
        textAnswerMiddle.text = "Hello";
        textMedium.SetActive(true);
    }

    private void BartyAppears()
    {
        MeterTracking();
        textMedium.SetActive(false);
        
        textBarty.text = "Who is this?";
        ShowTwoButtons();

        textAnswerLeft.text = "Someone who wants to talk to you.";
        buttonLeft.onClick.AddListener(StartA);
        
        textAnswerRight.text = "Someone who wants to get to know you.";
        buttonRight.onClick.AddListener(StartB);
    }

    private void StartA()
    {
        MeterTracking();
        currentDialogue = 0;
        doingA = true;
        RemoveListeners();
        ShowTwoButtons();

        buttonLeft.onClick.AddListener(ChoseLeft);
        buttonRight.onClick.AddListener(ChoseRight);

        textBarty.text = bartyA[currentDialogue];

        textAnswerLeft.text = answerLeftA[currentDialogue];
        textAnswerRight.text = answerRightA[currentDialogue];
    }

    private void NextDialogueA()
    {
        MeterTracking();
        if (currentDialogue < 3)
        {
            textBarty.text = bartyA[currentDialogue];

            textAnswerLeft.text = answerLeftA[currentDialogue];
            textAnswerRight.text = answerRightA[currentDialogue];
        }
        else
        {
            textBarty.text = bartyA[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "Let's find out together.";

            sadnessScore += 2;
            angerScore += 2;

            doingA = false;
            completedA = true;

            if (completedB)
            {
                buttonMiddle.onClick.AddListener(StartC);
            }
            else
            {
                buttonMiddle.onClick.AddListener(StartB);
            }
        }
    }

    private void StartB()
    {
        MeterTracking();
        currentDialogue = 0;
        doingB = true;
        RemoveListeners();
        ShowTwoButtons();

        buttonLeft.onClick.AddListener(ChoseLeft);
        buttonRight.onClick.AddListener(ChoseRight);

        textBarty.text = bartyB[currentDialogue];

        textAnswerLeft.text = answerLeftB[currentDialogue];
        textAnswerRight.text = answerRightB[currentDialogue];
    }

    private void NextDialogueB()
    {
        MeterTracking();
        if (currentDialogue < 2)
        {
            textBarty.text = bartyB[currentDialogue];

            textAnswerLeft.text = answerLeftB[currentDialogue];
            textAnswerRight.text = answerRightB[currentDialogue];
        }
        else
        {
            textBarty.text = bartyB[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "Hello Barty";

            sadnessScore++;
            angerScore++;

            doingB = false;
            completedB = true;

            if (completedA)
            {
                buttonMiddle.onClick.AddListener(StartC);

            }
            else
            {
                buttonMiddle.onClick.AddListener(StartA);
            }
        }
    }

    private void StartC()
    {
        MeterTracking();
        currentDialogue = 0;
        RemoveListeners();
        buttonMiddle.gameObject.SetActive(false);

        textBarty.text = "Why am I unable to leave this world?";

        if (completedC == false)
        {
            buttonRight.gameObject.SetActive(true);
            textAnswerRight.text = "Maybe something is holding you back.";
            buttonRight.onClick.AddListener(ContinueC);
        }
        if (completedC0 == false)
        {
            buttonLeft.gameObject.SetActive(true);
            textAnswerLeft.text = "Maybe it has something to do with how you died.";
            buttonLeft.onClick.AddListener(ContinueC0);
        }
    }

    private void ContinueC()
    {
        MeterTracking();
        doingC = true;
        RemoveListeners();

        if (currentDialogue < 2)
        {
            ShowTwoButtons();
            buttonLeft.onClick.AddListener(ChoseLeft);
            buttonRight.onClick.AddListener(ChoseRight);

            textBarty.text = bartyC[currentDialogue];

            textAnswerLeft.text = answerLeftC[currentDialogue];
            textAnswerRight.text = answerRightC[currentDialogue];
        }
        else
        {
            textBarty.text = bartyC[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "He died one year ago.";

            sadnessScore -= 4;

            doingC = false;
            completedC = true;

            if (angerScore <= -3)
            {
                buttonMiddle.onClick.AddListener(StartX);
            }
            else
            {
                buttonMiddle.onClick.AddListener(StartD);
            }
        }
    }

    private void ContinueC0()
    {
        MeterTracking();
        doingC0 = true;
        RemoveListeners();

        if (currentDialogue < 1)
        {
            ShowTwoButtons();
            textBarty.text = bartyC0[0];

            buttonLeft.onClick.AddListener(ChoseLeft);
            buttonRight.onClick.AddListener(ChoseRight);

            textAnswerLeft.text = "An object was involved in you death.";
            textAnswerRight.text = "The vase killed you.";
        }
        else if (currentDialogue == 1)
        {
            currentDialogue++;
            textBarty.text = bartyC0[1];

            ShowMiddleButton();
            buttonMiddle.onClick.AddListener(ContinueC0);
            textAnswerMiddle.text = "I could destroy the vase. What do you think?";
        }
        else if (currentDialogue > 1)
        {
            textBarty.text = bartyC0[2];
            textAnswerMiddle.text = "Okay!";

            sadnessScore -= 2;
            angerScore -= 2;

            doingC0 = false;
            completedC0 = true;

            if (angerScore <= -3)
            {
                buttonMiddle.onClick.AddListener(StartX);
            }
            else
            {
                buttonMiddle.onClick.AddListener(StartC);
            }
        }
    }

    private void StartX()
    {
        MeterTracking();
        currentDialogue = 0;
        doingX = true;
        RemoveListeners();
        ShowTwoButtons();

        buttonLeft.onClick.AddListener(ChoseLeft);
        buttonRight.onClick.AddListener(ChoseRight);

        textBarty.text = bartyX[currentDialogue];

        textAnswerLeft.text = answerLeftX[currentDialogue];
        textAnswerRight.text = answerRightX[currentDialogue];
    }

    private void NextDialogueX()
    {
        MeterTracking();
        if (currentDialogue < 2)
        {
            textBarty.text = bartyX[currentDialogue];

            textAnswerLeft.text = answerLeftX[currentDialogue];
            textAnswerRight.text = answerRightX[currentDialogue];
        }
        else
        {
            textBarty.text = bartyX[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "No, definetly not.";

            sadnessScore++;
            angerScore++;

            doingX = false;

            if (completedC)
            {
                buttonMiddle.onClick.AddListener(StartD);
            }
            else
            {
                buttonMiddle.onClick.AddListener(StartC);
            }
        }
    }

    private void StartD()
    {
        MeterTracking();
        currentDialogue = 0;
        doingD = true;
        RemoveListeners();
        ShowTwoButtons();

        buttonLeft.onClick.AddListener(ChoseLeft);
        buttonRight.onClick.AddListener(ChoseRight);

        textBarty.text = bartyD[currentDialogue];

        textAnswerLeft.text = answerLeftD[currentDialogue];
        textAnswerRight.text = answerRightD[currentDialogue];
    }

    private void NextDialogueD()
    {
        MeterTracking();
        if (currentDialogue < 6)
        {
            textBarty.text = bartyD[currentDialogue];

            textAnswerLeft.text = answerLeftD[currentDialogue];
            textAnswerRight.text = answerRightD[currentDialogue];
        }
        else
        {
            ShowMiddleButton();
            textAnswerMiddle.text = "End communication";

            if (sadnessScore < -4)
            {
                textBarty.text = "You know what, I don't trust you. I will stay here forever and keep an eye on everything. I will watch you and you won't change anything in the house!";
                buttonMiddle.onClick.AddListener(ShowBadEnding);
            }
            else
            {
                textBarty.text = "Thank you for your help, goodbye!";
                buttonMiddle.onClick.AddListener(ShowGoodEnding);
            }
        }
    }

    // opens the endscreen based on the outcome of the conversation
    private void ShowGoodEnding()
    {
        endscreen.SetActive(true);
        goodEndingText.SetActive(true);
    }

    private void ShowBadEnding()
    {
        endscreen.SetActive(true);
        badEndingText.SetActive(true);
    }

    // checks which dialogue was chosen based on a bool and current dialogue and changes the scores accordingly
    private void ChoseLeft()
    {
        currentDialogue++;
        if (doingA)
        {
            sadnessScore--;
            angerScore--;
            NextDialogueA();
            
        }
        if (doingB)
        {
            sadnessScore--;
            angerScore--;
            NextDialogueB();
        }
        if (doingC)
        {
            if (currentDialogue == 1)
            {
                sadnessScore--;
                angerScore++;
            }
            if (currentDialogue == 2)
            {
                sadnessScore--;
                angerScore++;
            }
            ContinueC();
        }
        if (doingC0)
        {
            if (currentDialogue == 1)
            {
                sadnessScore -= 2;
                angerScore--;
                ContinueC0();
            }
        }
        if (doingX)
        {
            sadnessScore++;
            angerScore++;
            NextDialogueX();
        }
        if (doingD)
        {
            if (currentDialogue <= 2)
            {
                sadnessScore -= 2;
                angerScore--;
            }
            else
            {
                sadnessScore--;
                angerScore--;
            }
            NextDialogueD();
        }
    }

    private void ChoseRight()
    {
        currentDialogue++;
        if (doingA)
        {
            sadnessScore--;
            angerScore++;
            NextDialogueA();
        }
        if (doingB)
        {
            sadnessScore++;
            angerScore++;
            NextDialogueB();
        }
        if (doingC)
        {
            if (currentDialogue == 1)
            {
                sadnessScore++;
                angerScore--;
            }
            if (currentDialogue == 2)
            {
                sadnessScore--;
            }
            ContinueC();
        }
        if (doingC0)
        {
            if (currentDialogue == 1)
            {
                sadnessScore -= 2;
                angerScore -= 2;
                ContinueC0();
            }
        }
        if (doingX)
        {
            sadnessScore++;
            angerScore++;
            NextDialogueX();
        }
        if (doingD)
        {
            if (currentDialogue <= 2)
            {
                sadnessScore++;
                angerScore++;
            }
            else
            {
                sadnessScore += 2;
                angerScore++;
            }
            NextDialogueD();
        }
    }

    // shows the left and right button every time there's two dialogue options
    private void ShowTwoButtons()
    {
        buttonLeft.gameObject.SetActive(true);
        buttonRight.gameObject.SetActive(true);
        buttonMiddle.gameObject.SetActive(false);
    }

    // shows the middle button every time there's only one dialogue option
    private void ShowMiddleButton()
    {
        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
        buttonMiddle.gameObject.SetActive(true);
    }

    // removes all listeners from the answer buttons
    private void RemoveListeners()
    {
        buttonLeft.onClick.RemoveAllListeners();
        buttonRight.onClick.RemoveAllListeners();
        buttonMiddle.onClick.RemoveAllListeners();   
    }

    // changes the shown level of sadness and anger according to the scores
    private void MeterTracking()
    {
        if (angerScore > 10)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.0f, 1f);
        }
        if (angerScore == 10 || angerScore == 9)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.09f, 1f);
        }
        if (angerScore == 8 || angerScore == 7) 
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.18f, 1f);
        }
        if (angerScore == 6 || angerScore == 5)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.27f, 1f);
        }
        if (angerScore == 4 || angerScore == 3)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.36f, 1f);
        }
        if (angerScore == 2 || angerScore == 1)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.45f, 1f);
        }
        if (angerScore == 0 || angerScore == -1)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.54f, 1f);
        }
        if (angerScore == -2 || angerScore == -3)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.63f, 1f);
        }
        if (angerScore == -4 || angerScore == -5)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.72f, 1f);
        }
        if (angerScore == -6 || angerScore == -7)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.81f, 1f);
        }
        if (angerScore < -7)
        {
            angerLevel.transform.localScale = new Vector3(1f, 0.9f, 1f);
        }
        /*if (angerScore ??)
        {
            angerLevel.transform.localScale = new Vector3(1f, 1f, 1f);
        }*/

        if (sadnessScore > 3)
        {
            sadnessLevel.transform.localScale = Vector3.zero;
        }
        if (sadnessScore == 3 || sadnessScore == 2)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.09f, 1f);
        }
        if (sadnessScore == 1 || sadnessScore == 0)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.18f, 1f);
        }
        if (sadnessScore == -1 || sadnessScore == -2)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.27f, 1f);
        }
        if (sadnessScore == -3 || sadnessScore == -4)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.36f, 1f);
        }
        if (sadnessScore == -5 || sadnessScore == -6)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.45f, 1f);
        }
        if (sadnessScore == -7 || sadnessScore == -8)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.54f, 1f);
        }
        if (sadnessScore == -9 || sadnessScore == -10)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.63f, 1f);
        }
        if (sadnessScore == -11 || sadnessScore == -12)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.72f, 1f);
        }
        if (sadnessScore == -13 || sadnessScore == -14)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.81f, 1f);
        }
        if (sadnessScore == -15 || sadnessScore == -16)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 0.9f, 1f);
        }
        if (sadnessScore < -16)
        {
            sadnessLevel.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}