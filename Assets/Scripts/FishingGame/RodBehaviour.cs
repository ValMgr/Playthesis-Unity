using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBehaviour : MonoBehaviour
{
    public static int BaitState = 0; // 0 : No Hook send, 1 : Hook Send, 2 : Bait on water
    public static float ImpulseStrength;
    public GameObject Hook;
    private GameObject RodTip;
    private GameObject RodBase;
    private GameObject PointTo;
    public float RodSpeed;
    public float RodUpperLimit;
    public float RodLowerLimit;
    public float RodLeftLimit;
    public float RodRightLimit;
    public float HookImpulseStrength;
    private Vector3 BaitInitPos;
    public static Quaternion RodIncli;
    public GameObject Bait;
    public static GameObject GBait;
    public int MaxBaitTime;
    public static int GMaxBaitTime;


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
                ThrowBait();
            }
        }

        if (Input.GetKey(KeyCode.X)) //Respawn Bait Provisoire
        {
            BaitState = 0;
        }

    }

    void ThrowBait()
    {
        ImpulseStrength = HookImpulseStrength;
        GMaxBaitTime = MaxBaitTime;
        RodIncli = transform.rotation;
        Vector3 RodTipV = RodTip.transform.position;
        BaitInitPos = new Vector3(RodTipV.x, RodTipV.y, RodTipV.z);
        Instantiate(Hook, BaitInitPos, RodIncli);
        BaitState = 1;
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
