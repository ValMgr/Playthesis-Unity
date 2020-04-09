using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehaviour : MonoBehaviour
{
    /* SCRIPT CONTROLANT LE HOOK */


    private Rigidbody Rb;                                                       //RigidBody du Hook
    private Vector3 ImpulsDir = RodBehaviour.RodIncli * Vector3.up;             //Direction dans laquel est tiré le hook
    private float ImpulsStrength;                                               //Force du tir


    private void Start()
    {
        ImpulsStrength = RodBehaviour.ImpulseStrength;
        Rb = GetComponent<Rigidbody>();
        Rb.AddForce( ImpulsStrength * ImpulsDir, ForceMode.Impulse);
        

    }

    private void Update()
    {
       
        if (transform.position.y < -20)
        {
            Instantiate(RodBehaviour.GBait);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HookTrigger")
        {
            Instantiate(RodBehaviour.GBait, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        RodBehaviour.BaitState = 2;
    }
}
