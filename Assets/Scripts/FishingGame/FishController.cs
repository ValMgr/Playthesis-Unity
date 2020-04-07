using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{

    public float TimeBetweenSpawn;
    public float DespawnTime;
    private bool CanSpawn = true;
    private bool WaitBwsOn = false;
    public static List<int> NumSqOn = new List<int>();




    private void Update()
    {

        int SpwNum = Random.Range(1, 12);

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
