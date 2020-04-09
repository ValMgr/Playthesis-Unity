using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{

    /* SCRIPT CONTROLANT L APPARITION DES POISSONS, LEUR DISPARITION, LEUR FREQUENCE, ETC */


    //Prefab des differents poissons
    public static GameObject FishB;
    public static GameObject FishR;
    public static GameObject FishG;
    public GameObject FishBlue;
    public GameObject FishRed;
    public GameObject FishGold;

    //Valeur de point de chacun des poissons
    public static int FishBlueV;
    public static int FishRedV;
    public static int FishGoldV;
    public int FishBlueValue;
    public int FishRedValue;
    public int FishGoldValue;

    //Probabilité d'apparition de chaque poisson, FishBlueP = 1 - (FishRedP+FishGoldP)
    public static float FishRedP;
    public static float FishGoldP;
    public float FishRedProba;
    public float FishGoldProba;

    //Temps que met un poisson à apparaître
    public float TimeBetweenSpawn;
    
    //Temps que met un poisson à disparaître
    public float DespawnTime;

    //Un Poisson peut t'il apparaitre ?
    private bool CanSpawn = true;

    //La coroutine WaitBetweenSpawn est elle activé ?
    private bool WaitBwsOn = false;

    //Liste Contenant les plateformes de spawn qui ont actuellement un poisson
    public static List<int> NumSqOn = new List<int>();

    private void Start()
    {
        FishB = FishBlue;
        FishR = FishRed;
        FishG = FishGold;
        FishBlueV = FishBlueValue;
        FishRedV = FishRedValue;
        FishGoldV = FishGoldValue;

        //Les Proba sont multiplié par 100 pour ne pas avoir à géré des floats
        FishRedP = FishRedProba*100;
        FishGoldP = FishGoldProba*100;
    }


    private void Update()
    {

        int SpwNum = Random.Range(1, 13); // Nombre entre 1 et 12 déterminant qu'elle plateforme de spawn doit faire apparaitre un poisson

        if (CanSpawn && !NumSqOn.Contains(SpwNum))
        {
            StartCoroutine(SpawnSequence(SpwNum));
        }

        if (!WaitBwsOn)
        {
            CanSpawn = false;
            StartCoroutine(WaitBetweenSpawn());

        }

    }

    IEnumerator WaitBetweenSpawn()
    {
        WaitBwsOn = true;
        yield return new WaitForSecondsRealtime(TimeBetweenSpawn);
        CanSpawn = true;
        WaitBwsOn = false;
    }

    IEnumerator SpawnSequence(int FishNum)
    {
        NumSqOn.Add(FishNum);
        yield return new WaitForSecondsRealtime(DespawnTime);
        NumSqOn.Remove(FishNum);

    }


}
