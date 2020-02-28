using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Destroy a floor if the floor is above the screen limit

        if (UpWall.UpWallPos.y < transform.position.y){
           Destroy(gameObject);
        }
    }

}
