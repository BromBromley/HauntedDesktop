using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumMatch : MonoBehaviour
{
    // this script scores the answers of the medium match

    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;

    private int witchScore;
    private int hippieScore;
    private int cyberScore;
    private int highestScore;

    private bool noTie = true;



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
