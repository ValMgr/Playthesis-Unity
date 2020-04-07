using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBehaviour : MonoBehaviour
{
    public static bool IsBaitOn = false;
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


        if (Input.GetKey(KeyCode.UpArrow) && PointTo.transform.position.y > -RodUpperLimit)
        {
            PointTo.transform.position = PointTo.transform.position + new Vector3(0,-RodSpeed, 0)  ;
        }
        if (Input.GetKey(KeyCode.DownArrow) && PointTo.transform.position.y < RodLowerLimit)
        {
            PointTo.transform.position = PointTo.transform.position + new Vector3(0, RodSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && PointTo.transform.position.x > -RodRightLimit)
        {
            PointTo.transform.position = PointTo.transform.position + new Vector3(-RodSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && PointTo.transform.position.x < RodLeftLimit)
        {
            PointTo.transform.position = PointTo.transform.position + new Vector3(RodSpeed, 0, 0);
        }

        RodBase.transform.rotation = Quaternion.LookRotation(PointTo.transform.position - RodBase.transform.position);

        if (Input.GetKey(KeyCode.Z)) //Z To shoot (for now)
        {
            if (!IsBaitOn)
            {
                ThrowBait();
            }
        }

        if (Input.GetKey(KeyCode.X)) //Respawn Bait Provisoire
        {
            IsBaitOn = false;
        }

    }

    void ThrowBait()
    {
        ImpulseStrength = HookImpulseStrength;
        RodIncli = transform.rotation;
        Vector3 RodTipV = RodTip.transform.position;
        BaitInitPos = new Vector3(RodTipV.x, RodTipV.y, RodTipV.z);
        Instantiate(Hook, BaitInitPos, RodIncli);
        IsBaitOn = true;
    }
}
