using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitBehaviour : MonoBehaviour
{
    private Rigidbody Rb;
    private Vector3 ImpulsDir = RodBehaviour.RodIncli * Vector3.up;
    private float ImpulsStrength = 4f;
    private void Start()
    {

        Rb = GetComponent<Rigidbody>();
        Debug.Log("X:" + ImpulsDir.x + "Y:" + ImpulsDir.y + "Z:" + ImpulsDir.z);
        Rb.AddForce( ImpulsStrength * ImpulsDir, ForceMode.Impulse);

    }

    private void Update()
    {

        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        RodBehaviour.IsBaitOn = false;
    }
}
