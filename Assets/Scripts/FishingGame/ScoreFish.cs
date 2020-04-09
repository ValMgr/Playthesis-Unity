using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreFish : MonoBehaviour
{

    /* SCRIPT CONTROLANT LE SCORE */


    public static int Score = 0;                    //Variable du score
    private Text ScoreTxt;                          //Composant texte


    void Start()
    {
        ScoreTxt = GetComponent<Text>();
    }

    void Update()
    {
        ScoreTxt.text = Score.ToString();

    }

}
