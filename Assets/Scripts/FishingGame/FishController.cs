using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public static GameObject FishB;
    public static GameObject FishR;
    public static GameObject FishG;
    public GameObject FishBlue;
    public GameObject FishRed;
    public GameObject FishGold;
    public static int FishBlueV;
    public static int FishRedV;
    public static int FishGoldV;
    public int FishBlueValue;
    public int FishRedValue;
    public int FishGoldValue;
    public static float FishRedP;
    public static float FishGoldP;
    public float FishRedProba;
    public float FishGoldProba;
    public float TimeBetweenSpawn;
    public float DespawnTime;
    private bool CanSpawn = true;
    private bool WaitBwsOn = false;
    public static List<int> NumSqOn = new List<int>();

    private void Start()
    {
        FishB = FishBlue;
        FishR = FishRed;
        FishG = FishGold;
        FishBlueV = FishBlueValue;
        FishRedV = FishRedValue;
        FishGoldV = FishGoldValue;
        FishRedP = FishRedProba*100;
        FishGoldP = FishGoldProba*100;
    }


    private void Update()
    {

        int SpwNum = Random.Range(1, 13);

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
        //Debug.Log("Fish Numéro :" + FishNum + "Doit Spawn !");
        yield return new WaitForSecondsRealtime(DespawnTime);
        //Debug.Log("Fish Numéro :" + FishNum + "Doit Despawn !");
        NumSqOn.Remove(FishNum);

    }


}
