using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBall : MonoBehaviour
{

    public static Vector2 pos {get; private set;}
    public GameObject target;


    void Update(){
        //Lock the x and z coordinates of the object and follow y pos of target
        // 5f on y axis is offset to keep ball to the top of the screen
        transform.position = new Vector3(0, target.transform.position.y -5f, -10); 
        pos = transform.position;
    }
}
