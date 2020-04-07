using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPlace : MonoBehaviour
{

    public int SpawnNumber;
    private Transform Fish;
    public static int BaitFishNum;

    private void Start()
    {
        Fish = gameObject.transform.Find("GameO");
        Fish.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (FishController.NumSqOn.Contains(SpawnNumber))
        {
            Fish.gameObject.SetActive(true);

        }
        else
        {
            Fish.gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Bait")
        {
            BaitFishNum = SpawnNumber;
        }
    }

}
