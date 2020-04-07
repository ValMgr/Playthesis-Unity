using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitBehaviour : MonoBehaviour
{
    private int MaxBaitTime = RodBehaviour.GMaxBaitTime;
    private int BaitIncr = 0;
    private bool OnFish = false;
    private bool WaitOn = false;
    private void Update()
    {
        if (!WaitOn)
        {
            StartCoroutine(Wait());
        }


        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }


    IEnumerator Wait()
    {
        WaitOn = true;
        if (Input.GetKey(KeyCode.A))
        {
            BaitIncr++;
            yield return new WaitForSecondsRealtime(0.001f);
            if (BaitIncr >= MaxBaitTime)
            {
                if (OnFish && FishController.NumSqOn.Contains(FishPlace.BaitFishNum))
                {
                    ScoreFish.Score++;
                    FishController.NumSqOn.Remove(FishPlace.BaitFishNum);
                    FishPlace.BaitFishNum = 0;
                    Debug.Log(ScoreFish.Score);
                }
                Destroy(gameObject);
            }
        }
        WaitOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fish")
        {
            OnFish = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fish")
        {
            OnFish = false;
        }
    }

    private void OnDestroy()
    {
        RodBehaviour.BaitState = 0;
    }
}
