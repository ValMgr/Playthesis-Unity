using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static Vector2 CameraPos;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, -10);
        CameraPos = transform.position;
    }
}
