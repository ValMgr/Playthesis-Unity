using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiko {
public class WorldGen : MonoBehaviour{

    // Group: Platform Prefabs
    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;

    // Group: Variables
    public float floorOffset = 3.2f; 
    private int yOffset = 0; 

    // Group: Functions
    /* Function: Start

        Instantiate 10 platforms instantly

    */
    void Start(){
        // Instantiate 10 platforms to start
        for (int i=0;i<10;i++){
            NewPlatform();
        }
    }

    
     /* Function: NewPlatform

        Instantiate a new platform with a random prefab

    */
    public void NewPlatform(){

            //Random Number who choose which "Ground" Prefab to use.
            int Rdm = Random.Range(1, 4); 
            GameObject platform;

            switch (Rdm){
                case 1:
                    platform = Instantiate(Ground1, new Vector3(Random.Range(-2.2f, 2.2f), floorOffset * -yOffset, 0), Quaternion.identity);
                    platform.transform.parent = gameObject.transform;
                    platform.name = "Platform" + yOffset;
                    break;

                case 2:
                    platform = Instantiate(Ground2, new Vector3(Random.Range(-2.2f, 2.2f), floorOffset * -yOffset, 0), Quaternion.identity);
                    platform.transform.parent = gameObject.transform;
                    platform.name = "Platform" + yOffset;
                    break;

                case 3:
                    platform = Instantiate(Ground3, new Vector3(Random.Range(-2.2f, 2.2f), floorOffset * -yOffset, 0), Quaternion.identity);
                    platform.transform.parent = gameObject.transform;
                    platform.name = "Platform" + yOffset;
                    break;

                default:
                    break;
            }

            yOffset++;
            
        }
            
     
}
}