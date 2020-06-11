using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiko {
public class GroundDestroyer : MonoBehaviour{
    // Update is called once per frame

    private GameObject limit;

    private void Start() {
        limit = GameObject.Find("Upwall");
    }
    
    /*  Function: Update
        
        Destroy plaftorm when it leaves screen, and create a new platform.        
    */
    void Update(){
        //Destroy a floor if the floor is above the screen limit
        if (limit.transform.position.y < transform.position.y){
           Destroy(gameObject);
           GameObject.Find("WorldGenerator").GetComponent<WorldGen>().NewPlatform();
        }
    }

}
}
