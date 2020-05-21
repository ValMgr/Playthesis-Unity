using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour{
    // Update is called once per frame

    private GameObject limit;

    private void Start() {
        limit = GameObject.Find("Upwall");
    }
    void Update(){
        //Destroy a floor if the floor is above the screen limit
        if (limit.transform.position.y < transform.position.y){
           Destroy(gameObject);
           GameObject.Find("WorldGenerator").GetComponent<WorldGen>().NewPlatform();
        }
    }

}
