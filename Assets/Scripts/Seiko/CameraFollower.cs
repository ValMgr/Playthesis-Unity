using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    //This Script makes object follow the y coordinates of the camera.

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, CameraController.CameraPos.y, 0);
    }
}
