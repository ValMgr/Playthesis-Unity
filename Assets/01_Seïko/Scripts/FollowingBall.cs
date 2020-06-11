using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiko {
public class FollowingBall : MonoBehaviour
{

    public static Vector2 position {get; private set;}
    public GameObject target;

    /*  Function: Update
        
        Follow Ball on y Axis

        Script attached to background & border walls.        
    */
    void Update(){
        //Lock the x and z coordinates of the object and follow y pos of target
        // 3.5f on y axis is offset to keep ball to the top of the screen
        transform.position = new Vector3(0, target.transform.position.y -3.5f, -10); 
        position = transform.position;
    }
}
}
