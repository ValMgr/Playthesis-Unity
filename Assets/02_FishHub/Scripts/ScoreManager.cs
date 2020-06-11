using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


namespace FishHub {
public class ScoreManager : MonoBehaviour {

    private int score;
    private Text scoreLabel;


    private void Start() {
        scoreLabel = this.GetComponent<Text>();
    }
    private void UpdateScore(){
        scoreLabel.text = score.ToString();
    }

    /* Function: AddScore

        Add fish's score to global score

        Parameters:

            value - Fish's value

     */
    public void AddScore(int value){
        score += value;
        UpdateScore();
    }
    
}

}