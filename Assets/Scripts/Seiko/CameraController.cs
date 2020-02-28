using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static Vector2 CameraPos;  //Camera's transform.position

    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, -10); //Lock the x and z coordinates of the camera
        CameraPos = transform.position;
    }
}
