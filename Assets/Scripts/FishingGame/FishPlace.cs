using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPlace : MonoBehaviour
{

    public int SpawnNumber;
    public static List<int> BaitFishNum = new List<int>();
    private int RdmFish = 0;
    private int ActualFish = 0;
    private bool FishOn = false;

    private void Start()
    {
        BaitFishNum.Add(SpawnNumber);
        BaitFishNum.Add(ActualFish);
    }

    private void Update()
    {
        if (FishController.NumSqOn.Contains(SpawnNumber))
        {
            if (!FishOn)
            {
                FishOn = true;
                RdmFish = Random.Range(0, 101);
                if (RdmFish <= FishController.FishGoldP)
                {
                    ActualFish = 3;
                    Instantiate(FishController.FishG, transform.position, Quaternion.identity, transform);
                }
                else if(RdmFish <= FishController.FishGoldP + FishController.FishRedP)
                {
                    ActualFish = 2;
                    Instantiate(FishController.FishR, transform.position, Quaternion.identity, transform);
                }
                else
                {
                    ActualFish = 1;
                    Instantiate(FishController.FishB, transform.position, Quaternion.identity, transform);            
                }
            }

        }
        else
        {
            RdmFish = 0;
            FishOn = false;
            int childs = transform.childCount;
            for (int i = childs - 1; i >= 0; i--)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Bait")
        {

            BaitFishNum.Clear();
            BaitFishNum = new List<int>();
            BaitFishNum.Add(SpawnNumber);
            BaitFishNum.Add(ActualFish);

        }
    }

}
