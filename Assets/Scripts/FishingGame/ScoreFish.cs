using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreFish : MonoBehaviour
{
    public static int Score = 0;

    private Text ScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        ScoreTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        // Script which set the Highest score of the player

        ScoreTxt.text = Score.ToString();

    }

}
