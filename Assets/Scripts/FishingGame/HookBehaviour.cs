using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehaviour : MonoBehaviour
{
    private Rigidbody Rb;
    private Vector3 ImpulsDir = RodBehaviour.RodIncli * Vector3.up;
    private float ImpulsStrength = RodBehaviour.ImpulseStrength;
    private void Start()
    {
        ImpulsStrength = RodBehaviour.ImpulseStrength;
        Rb = GetComponent<Rigidbody>();
        Rb.AddForce( ImpulsStrength * ImpulsDir, ForceMode.VelocityChange);
        

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
