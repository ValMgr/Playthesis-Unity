using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Seiko {
public class ScoreController : MonoBehaviour{
    private Text Score;

    /*  Function: Start
        
        Get Score Text GameObject
    */
    void Start(){
        Score = GetComponent<Text>();
    }

    /*  Function: Update
        
        Update Score Text with <PlayerBehavior.score>
    */
    void Update(){

        // Script which set the Highest score of the player
        Score.text = PlayerBehavior.score.ToString();

        if (PlayerPrefs.GetInt("ScoreSeiko",0) < PlayerBehavior.score)
        {
            if (PlayerPrefs.HasKey("ScoreSeiko") == true)
            {
                PlayerPrefs.DeleteKey("ScoreSeiko");
            }
            PlayerPrefs.SetInt("ScoreSeiko", PlayerBehavior.score);
        }
    }
}
}