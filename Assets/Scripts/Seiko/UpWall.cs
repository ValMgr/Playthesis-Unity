using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWall : MonoBehaviour
{
    public static Vector2 UpWallPos;

    //Make the transform.position of the Upper Limit of th screen accessible to every script.

    // Update is called once per frame
    void Update()
    {
        UpWallPos = transform.position;
    }
}
