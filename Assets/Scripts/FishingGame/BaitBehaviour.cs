using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitBehaviour : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

}
