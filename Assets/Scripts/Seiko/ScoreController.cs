using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = PlayerBehavior.CamCount.ToString();

        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteAll();
        }

        if (PlayerPrefs.GetInt("ScoreSeiko",0) < PlayerBehavior.CamCount)
        {
            if (PlayerPrefs.HasKey("ScoreSeiko") == true)
            {
                PlayerPrefs.DeleteKey("ScoreSeiko");
            }
            PlayerPrefs.SetInt("ScoreSeiko", PlayerBehavior.CamCount);
        }
    }
}
