using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBehaviour : MonoBehaviour
{
    public static bool IsBaitOn = false;
    public GameObject Bait;
    public GameObject RodTip;
    private Vector3 BaitInitPos;
    public static Quaternion RodIncli;

    private void Start()
    {
        RodTip = GameObject.Find("RodTip");
    }

    private void Update()
    {

        //Mathf.Abs(transform.parent.transform.position.y - RodTip.transform.position.y) / 4f
        Debug.Log(Mathf.Asin(1/2));

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
        RodIncli = transform.rotation;
        Vector3 RodTipV = RodTip.transform.position;
        BaitInitPos = new Vector3(RodTipV.x, RodTipV.y, RodTipV.z);
        Instantiate(Bait, BaitInitPos, RodIncli);
        IsBaitOn = true;
    }
}
