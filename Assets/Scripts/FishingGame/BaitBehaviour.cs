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


        if (transform.position.y < -20 || RodBehaviour.BaitState == 0)
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
                if (OnFish && FishController.NumSqOn.Contains(FishPlace.BaitFishNum[0])) //Cette ligne renvoie parfois une ArgumentOutOfRangeException, j'arrive pas à trouver la raison,
                {                                                                       // et le jeu fonctionne comme si l'erreur ne se produisait pas. Donc pour le moment ce bug n'est pas corrigé.
                    switch (FishPlace.BaitFishNum[1])
                    {
                        case 1:
                            ScoreFish.Score += FishController.FishBlueV;
                            break;
                        case 2:
                            ScoreFish.Score += FishController.FishRedV;
                            break;
                        case 3:
                            ScoreFish.Score += FishController.FishGoldV;
                            break;
                        default:
                            break;
                    }
                    
                    FishController.NumSqOn.Remove(FishPlace.BaitFishNum[0]);
                    FishPlace.BaitFishNum.Clear();
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
