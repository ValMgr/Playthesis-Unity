using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBehaviour : MonoBehaviour
{
    /* SCRIPT CONTROLANT LA CANNE A PECHE */


    /* Le Hook (Hamecon) est la boule envoyé lorsqu'on appuie sur Z, le Bait (Flotteur) est ce qui flotte sur l'eau */


    public static int BaitState = 0; // 0 : No Hook send, 1 : Hook Send, 2 : Bait on water

    //Force de l'impulsion
    public static float ImpulseStrength; 
    public float HookImpulseStrength;

    //Temps en millisecondes necessaire pour remonter le bait
    public int MaxBaitTime;
    public static int GMaxBaitTime;

    //Prefab du bait
    public GameObject Bait;
    public static GameObject GBait;

    //Prefab du Bait
    public GameObject Hook; 


    private GameObject RodTip;              //Bout supérieur de la canne à pêche, c'est de la que par le hook
    private GameObject RodBase;             //Bas de la canne à pêche
    private GameObject PointTo;             //Objet permettant le mouvement de la canne à pêche

 
    public float RodSpeed;                  //Vitesse de la canne à pêche

    public float RodUpperLimit;             //Limite supérieur du mouvement de la canne à pêche
    public float RodLowerLimit;             //Limite supérieur du mouvement de la canne à pêche
    public float RodLeftLimit;              //Limite supérieur du mouvement de la canne à pêche
    public float RodRightLimit;             //Limite supérieur du mouvement de la canne à pêche

    public static Quaternion RodIncli;      //Inclinaison de la canne à pêche




    private void Start()
    {
        GBait = Bait;
        RodTip = GameObject.Find("RodTip");
        RodBase = GameObject.Find("RodBase");
        PointTo = GameObject.Find("PointTo");
        RodSpeed = RodSpeed / 100;

    }

    private void Update()
    {

        MoveRod();


        if (Input.GetKey(KeyCode.Z)) //Z To shoot (for now)
        {
            if (BaitState == 0)
            {
                ThrowHook();
            }
        }

        if (Input.GetKey(KeyCode.X)) //Respawn Bait Provisoire
        {
            BaitState = 0;
        }

    }

    void ThrowHook()
    {
        ImpulseStrength = HookImpulseStrength;
        GMaxBaitTime = MaxBaitTime;
        RodIncli = RodBase.transform.rotation;
        Instantiate(Hook, RodTip.transform.position, RodIncli);
        BaitState = 1;
        AudioController.SoundToPlay = 1;
    }

    void MoveRod()
    {

        if (Input.GetKey(KeyCode.RightArrow) && PointTo.transform.position.x > -RodRightLimit)
        {
            PointTo.transform.position = PointTo.transform.position + new Vector3(-RodSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && PointTo.transform.position.x < RodLeftLimit)
        {
            PointTo.transform.position = PointTo.transform.position + new Vector3(RodSpeed, 0, 0);
        }

        RodBase.transform.rotation = Quaternion.LookRotation(PointTo.transform.position - RodBase.transform.position);
    }
}
