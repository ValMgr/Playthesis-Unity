using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject UICanvas;
    private GameObject UIStats;
    private GameObject UIDidacticiel;
    // Start is called before the first frame update
    void Start()
    {
        UICanvas = GameObject.Find("Canvas");
        UIStats = GameObject.Find("Stats");
        UIDidacticiel = GameObject.Find("UIDidacticiel");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void Switch(string scenename)
    {
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
    }

    public void StatsSeiko(bool click)
    {

        UICanvas.SetActive(click);
    } 
    
    public void DidacticielSeiko(bool click)
    {

        UICanvas.SetActive(click);
        UIStats.SetActive(click);

    }


}
