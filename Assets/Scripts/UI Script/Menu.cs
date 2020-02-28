using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject UICanvas;
    private GameObject UIStats;
    // Start is called before the first frame update
    void Start()
    {
        UICanvas = GameObject.Find("Canvas");
        UIStats = GameObject.Find("Stats");
    }


    //Reset all player prefs (for resetting the score)

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    //Change the Scene, scenename is set in the inspector
    public void Switch(string scenename)
    {
        SceneManager.LoadScene(scenename, LoadSceneMode.Single); 
    }

    //On click show the page "Stats" of Seiko Menu
    public void StatsSeiko(bool click)
    {

        UICanvas.SetActive(click);
    } 
    //On click show the page "Comment Jouer ?" de Seiko
    public void DidacticielSeiko(bool click)
    {

        UICanvas.SetActive(click);
        UIStats.SetActive(click);

    }


}
