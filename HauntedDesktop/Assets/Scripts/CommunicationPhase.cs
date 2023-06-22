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

        textBarty = textBarty.GetComponent<TMP_Text>();
        textBarty.text = "";
    }

    private void AssignArrays()
    {
        bartyA[0] = "Mit mir hat schon lange keiner mehr gesprochen";
        bartyA[1] = "Ja";
        bartyA[2] = "Es ist wie ein Alptraum, aus dem man nicht aufwachen kann";
        bartyA[3] = "Ich weiß nicht, wie das funktionieren soll";
        answerLeftA[0] = "Du bist ja auch ein Geist";
        answerLeftA[1] = "Es ist bestimmt irgendwie cool ein Geist zu sein";
        answerLeftA[2] = "Warum gehst du nicht einfach?";
        answerRightA[0] = "Du bist bestimmt einsam";
        answerRightA[1] = "Ich stelle es mir schrecklich vor ein Geist zu sein";
        answerRightA[2] = "Kannst du nicht gehen?";

        bartyB[0] = "Wenn du wissen willst, wer ich bin, dann stell mir Fragen";
        bartyB[1] = "Ja";
        bartyB[2] = "Ich bin Barty, Reginald ist mein Bruder";
        answerLeftB[0] = "Bist du hier gestorben?";
        answerLeftB[1] = "Bist du Reginald Montgomery?";
        answerRightB[0] = "Wohnst du hier?";
        answerRightB[1] = "Bist du Bartholomew Montgomery?";

        bartyC[0] = "Woran denkst du?";
        bartyC[1] = "Das stimmt, mein Bruder lässt für mich im Haus alles so, wie es immer war";
        bartyC[2] = "Was? Was ist mit meinem Bruder?";
        answerLeftC[0] = "Im Haus hat sich doch nichts veränder, seit du ein Geist bist";
        answerLeftC[1] = "Jetzt wohne ich aber hier";
        answerRightC[0] = "Du magst es nicht, wenn sich im Haus Dinge verändern";
        answerRightC[1] = "Dein Bruder ist nicht mehr hier";

        bartyC0[0] = "Wie meinst du das?";
        bartyC0[1] = "Ja";
        bartyC0[2] = "Spinnst du?! Hier bleibt alles so, wie es ist!";

        bartyX[0] = "Ich will nicht mehr mit dir reden, ich glaube dir gar nichts mehr!";
        bartyX[1] = "Warum soll ich dir das glauben?";
        bartyX[2] = "Und ich dachte, du wärst ein Einbrecher oder Hausbesetzer";
        answerLeftX[0] = "Sei doch nicht wütend, ich will dir nur helfen";
        answerLeftX[1] = "Du bist mein Urgroßcousin, ich bin Teil deiner Familie";
        answerRightX[0] = "Ich will dir nichts böses";
        answerRightX[1] = "Wir sind verwandt, ich bekomme das Familienerbe";

        bartyD[0] = "Reginald tot? Das darf nicht sein!";
        bartyD[1] = "Wie alt war er?";
        bartyD[2] = "So alt... Das heißt ja, dass ich schon seit 94 Jahren tot bin";
        bartyD[3] = "Alles ist so anders, das wollte ich doch verhindern";
        bartyD[4] = "Ich muss doch auf alles aufpasssen";
        bartyD[5] = "Du meinst, ich kann einfach gehen?";
        answerLeftD[0] = "Wir müssen alle irgendwann sterben";
        answerLeftD[1] = "Er ist 102 geworden, am Ende war er sehr alleine";
        answerLeftD[2] = "Du solltest endlich gehen";
        answerLeftD[3] = "Veränderung ist nichts schlechtes";
        answerLeftD[4] = "Das musst du nicht";
        answerLeftD[5] = "Du hättest die ganze Zeit gehen können";
        answerRightD[0] = "Er war schon sehr alt";
        answerRightD[1] = "Er wurde 102, sein Leben war lang und erfüllt";
        answerRightD[2] = "Ja, es ist Zeit für dich loszulassen";
        answerRightD[3] = "Ich kann verstehen, dass dir das Angst macht";
        answerRightD[4] = "Ich bin jetzt hier, ich passe auf";
        answerRightD[5] = "Ja, geh zu Reginald";
    }

    public void StartConversation()
    {
        AssignArrays();
        ShowMiddleButton();
        buttonMiddle.onClick.AddListener(BartyAppears);
        textAnswerMiddle.text = "Hallo";
        textMedium.SetActive(true);
    }

    private void BartyAppears()
    {
        textMedium.SetActive(false);
        
        textBarty.text = "Wer ist da?";
        ShowTwoButtons();

        textAnswerLeft.text = "Jemand, der mit dir reden möchte";
        buttonLeft.onClick.AddListener(StartA);
        
        textAnswerRight.text = "Jemand, der dich kennenlernen möchte";
        buttonRight.onClick.AddListener(StartB);
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
    }

    private void NextDialogueA()
    {
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
            textAnswerMiddle.text = "Lass es uns gemeinsam herausfinden";

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
            textAnswerMiddle.text = "Hallo, Barty";

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
        currentDialogue = 0;
        RemoveListeners();
        buttonMiddle.gameObject.SetActive(false);

        textBarty.text = "Warum kann ich hier bloß nicht weg?";

        if (completedC == false)
        {
            buttonRight.gameObject.SetActive(true);
            textAnswerRight.text = "Vielleicht gibt es etwas, was dich hier hält";
            buttonRight.onClick.AddListener(ContinueC);
        }
        if (completedC0 == false)
        {
            buttonLeft.gameObject.SetActive(true);
            textAnswerLeft.text = "Vielleicht hängt es mit deiner Todesursache zusammen";
            buttonLeft.onClick.AddListener(ContinueC0);
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
        }
        else
        {
            textBarty.text = bartyC[currentDialogue];

            ShowMiddleButton();
            textAnswerMiddle.text = "Er ist vor einem Jahr gestorben";

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
        doingC0 = true;
        RemoveListeners();

        if (currentDialogue < 1)
        {
            ShowTwoButtons();
            textBarty.text = bartyC0[0];

            buttonLeft.onClick.AddListener(ChoseLeft);
            buttonRight.onClick.AddListener(ChoseRight);

            textAnswerLeft.text = "Ein Gegenstand war involviert";
            textAnswerRight.text = "Die Vase hat dich umgebracht";
        }
        else if (currentDialogue == 1)
        {
            currentDialogue++;
            textBarty.text = bartyC0[1];

            ShowMiddleButton();
            buttonMiddle.onClick.AddListener(ContinueC0);
            textAnswerMiddle.text = "Was hälst du davon, wenn ich die Vase zerstöre?";
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
            textAnswerMiddle.text = "Nein, da liegst du falsch";

            sadnessScore++;
            angerScore++;

            doingX = false;

            if (completedC)
            {
                buttonMiddle.onClick.AddListener(StartC);
            }
            else
            {
                buttonMiddle.onClick.AddListener(StartD);
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
    }

    private void NextDialogueD()
    {
        if (currentDialogue < 6)
        {
            textBarty.text = bartyD[currentDialogue];

            textAnswerLeft.text = answerLeftD[currentDialogue];
            textAnswerRight.text = answerRightD[currentDialogue];
        }
        else
        {
            buttonLeft.gameObject.SetActive(false);
            buttonRight.gameObject.SetActive(false);

            if (sadnessScore < -4)
            {
                textBarty.text = "Weißt du was, ich vertraue dir nicht. Ich bleibe hier und werde für iimer auf diese Haus aufpassen.";
            }
            else
            {
                textBarty.text = "Danke für deine Hilfe, mach's gut!";
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
}