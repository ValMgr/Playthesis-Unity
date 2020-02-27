using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HScoreDisplay : MonoBehaviour
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
        Score.text = PlayerPrefs.GetInt("ScoreSeiko", 0).ToString();
    }
}
