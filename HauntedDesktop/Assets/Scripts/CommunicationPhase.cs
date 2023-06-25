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

    // Score visualization
    [SerializeField] private GameObject sadnessMeter;
    [SerializeField] private GameObject angerMeter;
    [SerializeField] private GameObject sadnessScoreMinusEight;
    [SerializeField] private GameObject sadnessScoreMinusSix;
    [SerializeField] private GameObject sadnessScoreMinusFour;
    [SerializeField] private GameObject sadnessScoreMinusTwo;
    [SerializeField] private GameObject sadnessScoreZero;
    [SerializeField] private GameObject sadnessScoreTwo;
    [SerializeField] private GameObject sadnessScoreFour;
    [SerializeField] private GameObject sadnessScoreSix;
    [SerializeField] private GameObject sadnessScoreEight;

    [SerializeField] private GameObject angerScoreMinusEight;
    [SerializeField] private GameObject angerScoreMinusSix;
    [SerializeField] private GameObject angerScoreMinusFour;
    [SerializeField] private GameObject angerScoreMinusTwo;
    [SerializeField] private GameObject angerScoreZero;
    [SerializeField] private GameObject angerScoreTwo;
    [SerializeField] private GameObject angerScoreFour;
    [SerializeField] private GameObject angerScoreSix;
    [SerializeField] private GameObject angerScoreEight;
    

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

        angerMeter.SetActive(false);
        sadnessMeter.SetActive(false);

        textBarty = textBarty.GetComponent<TMP_Text>();
        textBarty.text = "";
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
        bartyC[2] = "hat?! What happened to my brother?";
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
        textMedium.SetActive(false);
        
        textBarty.text = "Who is this?";
        ShowTwoButtons();

        textAnswerLeft.text = "Someone who wants to talk to you.";
        buttonLeft.onClick.AddListener(StartA);
        
        textAnswerRight.text = "Someone who wants to get to know you.";
        buttonRight.onClick.AddListener(StartB);
        
        MeterTracking();

    }

    private void StartA()
    {
        currentDialogue = 0;
        doingA = true;
        RemoveListeners();
        ShowTwoButtons();

        buttonLeft.onClick.AddListener(ChoseLeft);
        buttonRight.onClick.AddListener(ChoseRight);

        textBarty.text = bartyA[currentDialogue];

        textAnswerLeft.text = answerLeftA[currentDialogue];
        textAnswerRight.text = answerRightA[currentDialogue];
        MeterTracking();
    
    }

    private void NextDialogueA()
    {
        if (currentDialogue < 3)
        {
            textBarty.text = bartyA[currentDialogue];

            textAnswerLeft.text = answerLeftA[currentDialogue];
            textAnswerRight.text = answerRightA[currentDialogue];
            MeterTracking();
        }
        else
        {
            textBarty.text = bartyA[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "Let's find out together.";

            sadnessScore += 2;
            angerScore += 2;
            MeterTracking();

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
        currentDialogue = 0;
        doingB = true;
        RemoveListeners();
        ShowTwoButtons();

        buttonLeft.onClick.AddListener(ChoseLeft);
        buttonRight.onClick.AddListener(ChoseRight);

        textBarty.text = bartyB[currentDialogue];

        textAnswerLeft.text = answerLeftB[currentDialogue];
        textAnswerRight.text = answerRightB[currentDialogue];
        MeterTracking();
    }

    private void NextDialogueB()
    {
        if (currentDialogue < 2)
        {
            textBarty.text = bartyB[currentDialogue];

            textAnswerLeft.text = answerLeftB[currentDialogue];
            textAnswerRight.text = answerRightB[currentDialogue];
            MeterTracking();
        }
        else
        {
            textBarty.text = bartyB[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "Hello Barty";

            sadnessScore++;
            angerScore++;
            MeterTracking();

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
        currentDialogue = 0;
        RemoveListeners();
        buttonMiddle.gameObject.SetActive(false);

        textBarty.text = "Why am I unable to leave this world?";

        if (completedC == false)
        {
            buttonRight.gameObject.SetActive(true);
            textAnswerRight.text = "Maybe something is holding you back.";
            buttonRight.onClick.AddListener(ContinueC);
            MeterTracking();
        }
        if (completedC0 == false)
        {
            buttonLeft.gameObject.SetActive(true);
            textAnswerLeft.text = "Maybe it has something to do with how you died.";
            buttonLeft.onClick.AddListener(ContinueC0);
            MeterTracking();
        }
    }

    private void ContinueC()
    {
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
            MeterTracking();
        }
        else
        {
            textBarty.text = bartyC[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "He died one year ago.";

            sadnessScore -= 4;

            doingC = false;
            completedC = true;
            MeterTracking();

            if (angerScore <= -3)
            {
                buttonMiddle.onClick.AddListener(StartX);
                MeterTracking();
            }
            else
            {
                buttonMiddle.onClick.AddListener(StartD);
                MeterTracking();
            }
        }
    }

    private void ContinueC0()
    {
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
            MeterTracking();
        }
        else if (currentDialogue == 1)
        {
            currentDialogue++;
            textBarty.text = bartyC0[1];

            ShowMiddleButton();
            buttonMiddle.onClick.AddListener(ContinueC0);
            textAnswerMiddle.text = "I could destroy the vase. What do you think?";
            MeterTracking();
        }
        else if (currentDialogue > 1)
        {
            textBarty.text = bartyC0[2];
            textAnswerMiddle.text = "Okay!";

            sadnessScore -= 2;
            angerScore -= 2;
            MeterTracking();

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
        currentDialogue = 0;
        doingX = true;
        RemoveListeners();
        ShowTwoButtons();

        buttonLeft.onClick.AddListener(ChoseLeft);
        buttonRight.onClick.AddListener(ChoseRight);

        textBarty.text = bartyX[currentDialogue];

        textAnswerLeft.text = answerLeftX[currentDialogue];
        textAnswerRight.text = answerRightX[currentDialogue];
        MeterTracking();
    }

    private void NextDialogueX()
    {
        if (currentDialogue < 2)
        {
            textBarty.text = bartyX[currentDialogue];

            textAnswerLeft.text = answerLeftX[currentDialogue];
            textAnswerRight.text = answerRightX[currentDialogue];
            MeterTracking();
        }
        else
        {
            textBarty.text = bartyX[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "No, definetly not.";

            sadnessScore++;
            angerScore++;
            MeterTracking();

            doingX = false;

            if (completedC)
            {
                buttonMiddle.onClick.AddListener(StartD);
                MeterTracking();
            }
            else
            {
                buttonMiddle.onClick.AddListener(StartC);
                MeterTracking();
            }
        }
    }

    private void StartD()
    {
        currentDialogue = 0;
        doingD = true;
        RemoveListeners();
        ShowTwoButtons();

        buttonLeft.onClick.AddListener(ChoseLeft);
        buttonRight.onClick.AddListener(ChoseRight);

        textBarty.text = bartyD[currentDialogue];

        textAnswerLeft.text = answerLeftD[currentDialogue];
        textAnswerRight.text = answerRightD[currentDialogue];
        MeterTracking();
    }

    private void NextDialogueD()
    {
        if (currentDialogue < 6)
        {
            textBarty.text = bartyD[currentDialogue];

            textAnswerLeft.text = answerLeftD[currentDialogue];
            textAnswerRight.text = answerRightD[currentDialogue];
            MeterTracking();
        }
        else
        {
            buttonLeft.gameObject.SetActive(false);
            buttonRight.gameObject.SetActive(false);

            if (sadnessScore < -4)
            {
                textBarty.text = "You know what, I don't trust you. I will stay here forever and keep an eye on everything. I will watch you and you won't change anything in the house!";
            MeterTracking();
            }
            else
            {
                textBarty.text = "Thank you for your help, goodbye!";
                MeterTracking();
            }
        }
    }

    private void ChoseLeft()
    {
        currentDialogue++;
        if (doingA)
        {
            sadnessScore--;
            angerScore--;
            MeterTracking();
            NextDialogueA();
            
        }
        if (doingB)
        {
            sadnessScore--;
            angerScore--;
            MeterTracking();
            NextDialogueB();
        }
        if (doingC)
        {
            if (currentDialogue == 1)
            {
                sadnessScore--;
                angerScore++;
                MeterTracking();
            }
            if (currentDialogue == 2)
            {
                sadnessScore--;
                angerScore++;
                MeterTracking();
            }
            ContinueC();
        }
        if (doingC0)
        {
            if (currentDialogue == 1)
            {
                sadnessScore -= 2;
                angerScore--;
                MeterTracking();
                ContinueC0();
            }
        }
        if (doingX)
        {
            sadnessScore++;
            angerScore++;
            MeterTracking();
            NextDialogueX();
        }
        if (doingD)
        {
            if (currentDialogue <= 2)
            {
                sadnessScore -= 2;
                angerScore--;
                MeterTracking();
            }
            else
            {
                sadnessScore--;
                angerScore--;
                MeterTracking();
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
            MeterTracking();
            NextDialogueA();
        }
        if (doingB)
        {
            sadnessScore++;
            angerScore++;
            MeterTracking();
            NextDialogueB();
        }
        if (doingC)
        {
            if (currentDialogue == 1)
            {
                sadnessScore++;
                angerScore--;
                MeterTracking();
            }
            if (currentDialogue == 2)
            {
                sadnessScore--;
                MeterTracking();
            }
            ContinueC();
        }
        if (doingC0)
        {
            if (currentDialogue == 1)
            {
                sadnessScore -= 2;
                angerScore -= 2;
                MeterTracking();
                ContinueC0();
            }
        }
        if (doingX)
        {
            sadnessScore++;
            angerScore++;
            MeterTracking();
            NextDialogueX();
        }
        if (doingD)
        {
            if (currentDialogue <= 2)
            {
                sadnessScore++;
                angerScore++;
                MeterTracking();
            }
            else
            {
                sadnessScore += 2;
                angerScore++;
                MeterTracking();
            }
            NextDialogueD();
        }
    }

    private void ShowTwoButtons()
    {
        buttonLeft.gameObject.SetActive(true);
        buttonRight.gameObject.SetActive(true);
        buttonMiddle.gameObject.SetActive(false);
    }

    private void ShowMiddleButton()
    {
        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
        buttonMiddle.gameObject.SetActive(true);
    }

    private void RemoveListeners()
    {
        buttonLeft.onClick.RemoveAllListeners();
        buttonRight.onClick.RemoveAllListeners();
        buttonMiddle.onClick.RemoveAllListeners();   
    }

    private void MeterTracking()
    {
        sadnessMeter.SetActive(true);
        angerMeter.SetActive(true);
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(true);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);

        angerScoreEight.SetActive(false);
        angerScoreSix.SetActive(false);
        angerScoreFour.SetActive(false);
        angerScoreTwo.SetActive(false);
        angerScoreZero.SetActive(true);
        angerScoreMinusTwo.SetActive(false);
        angerScoreMinusFour.SetActive(false);
        angerScoreMinusSix.SetActive(false);
        angerScoreMinusEight.SetActive(false);
        // Sadness_Meter 
      if (sadnessScore== -8)
      {
        sadnessScoreMinusEight.SetActive(true);
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        }

        if (sadnessScore== -7)
      {
        sadnessScoreMinusEight.SetActive(true);
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        }
        

        if (sadnessScore== -6)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(true);
        sadnessScoreMinusEight.SetActive(false);
        }

        if (sadnessScore== -5)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(true);
        sadnessScoreMinusEight.SetActive(false);
        }

        if (sadnessScore== -4)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(true);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }
        
        if (sadnessScore== -3)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(true);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }
        
        if (sadnessScore== -2)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(true);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }
        if (sadnessScore== -1)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(true);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }
        
      if (sadnessScore== 0)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(true);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }

        if (sadnessScore== 1)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(true);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }

        if (sadnessScore== 2)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(true);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }
        
        if (sadnessScore== 3)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(true);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }

        if (sadnessScore== 4)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(true);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }

        if (sadnessScore== 5)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(true);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }

        if (sadnessScore== 6)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(true);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }
         if (sadnessScore== 7)
        {
        sadnessScoreEight.SetActive(false);
        sadnessScoreSix.SetActive(true);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }

        if (sadnessScore== 8)
      {
        sadnessScoreEight.SetActive(true);
        sadnessScoreSix.SetActive(false);
        sadnessScoreFour.SetActive(false);
        sadnessScoreTwo.SetActive(false);
        sadnessScoreZero.SetActive(false);
        sadnessScoreMinusTwo.SetActive(false);
        sadnessScoreMinusFour.SetActive(false);
        sadnessScoreMinusSix.SetActive(false);
        sadnessScoreMinusEight.SetActive(false);
        }

        // Anger_Meter 
      if (angerScore>-8& angerScore<-7)
      {
        angerScoreMinusEight.SetActive(true);
        angerScoreMinusSix.SetActive(false);
        }

        if (angerScore>-6& angerScore<=-5)
        {
          angerScoreMinusSix.SetActive(true);
          angerScoreMinusEight.SetActive(false);
          angerScoreMinusFour.SetActive(false);
        }

        if (angerScore>-4& angerScore<-3)
       {
          angerScoreMinusFour.SetActive(true);
          angerScoreMinusTwo.SetActive(false);
          angerScoreMinusSix.SetActive(false);
        }
        if (angerScore>-2& angerScore<-1)
       {
          angerScoreMinusTwo.SetActive(true);
          angerScoreZero.SetActive(false);
          angerScoreMinusFour.SetActive(false);
        }
        
        if (angerScore>0& angerScore<1)
       {
         angerScoreZero.SetActive(true);
          angerScoreMinusTwo.SetActive(false);
          angerScoreTwo.SetActive(false);
        }

        if (angerScore>2& angerScore<3)
       {
          angerScoreTwo.SetActive(true);
          angerScoreZero.SetActive(false);
          angerScoreFour.SetActive(false);
        }

        if (angerScore>4& angerScore<5)
       {
          angerScoreFour.SetActive(true);
         angerScoreTwo.SetActive(false);
         angerScoreSix.SetActive(false);
        }

        if (angerScore>5& angerScore<6)
        {
          angerScoreSix.SetActive(true);
          angerScoreEight.SetActive(false);
          angerScoreFour.SetActive(false);
        }

        if (angerScore>7& angerScore<8)
      {
        angerScoreEight.SetActive(true);
        angerScoreSix.SetActive(false);
        }


    }
}