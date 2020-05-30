using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FishHub {
public class FishBehaviour : MonoBehaviour {
    
    // Group: Variables
    private FishManager FishManager;
    [SerializeField]
    [Range(0f, 10f)]
    private float speed = 2f;

    // Group: Waypoints variables
    private Vector3 currentWP;
    private Vector3 lastWP;
    // Group: State variables
    private bool baited;
    private bool hooked;
    private bool hasTarget = false;
    private bool isTurning = false;

    // Group: Fish properties
    public int value {get; private set;}
    public float fTime {get; private set;}



    // Group: Functions

    /*  Function: Start
    
        Find FishManager component
    */
    private void Start() {
        FishManager = transform.parent.transform.parent.GetComponent<FishManager>();
    }


    /*  Function: Update

        Looking for waypoints.
        Detect if waypoints reached.

        See Also:
            <FindTarget>
    */

    private void Update() {

        // Looking for wp (waypoint)
        if(!hasTarget){
            hasTarget = FindTarget();
        }
        // If wp isnt a hook, swim towards wp
        else if(!hooked){
            RotateFish(currentWP, speed);
            transform.position = Vector3.MoveTowards(transform.position, currentWP, speed * Time.deltaTime);
        }
        
        // If wp reached, reset hasTarget status then look for new wp
        if(transform.position == currentWP && !baited){
            hasTarget = false;
        }
        // If hook reached call Fishing method from HookBehaviour scripts
        if(transform.position == currentWP && baited){
           
            if(!hooked){
                GameObject.Find("Hook").GetComponent<HookBehaviour>().Fishing();
            }
            hooked = true;
        }
    }


    /* Function: FindTarget

        Find a new random position and give a random speed.
         
        Parameters:

        start - Minimum Speed.
        end - Maximum Speed.

        Returns:
            Boolean if target acquired.

     */
    private bool FindTarget(float start = 1f, float end = 5f){
        currentWP = FishManager.RandomPosition();
        if(lastWP == currentWP){
            currentWP = FishManager.RandomPosition();
            return false;
        }
        else{
            lastWP = currentWP;
            speed = Random.Range(start, end);
            return true;
        }

    }

    /* Function: RotateFish

        Rotate fish to look at current waypoint.
         
        Parameters:

        waypoint - Position to reach.
        currentspeed - Speed.


     */
    private void RotateFish(Vector3 waypoint, float currentspeed){

        float RotSpeed = currentspeed * Random.Range(1f, 3f);
        Vector3 LookAt = waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookAt), RotSpeed * Time.deltaTime);

    }

      /* Function: Baited

        Change current waypoint with Hook position.
         
        Parameters:

        HookPosition - Hook Vector3 position.

     */
    public void Baited(Vector3 HookPosition){
        currentWP = new Vector3(HookPosition.x, HookPosition.y -.25f, HookPosition.z);
        speed = Random.Range(0.5f, 1.5f);
        baited = true;
    }

    // Function: ReleaseFish
    // Release baited fish       
    public void ReleaseFish(){
        hooked = false;
        hasTarget = false;
        baited = false;
    }

    /* Function: SetValue

        Set values defined by fish groups.
     
        Parameters:
     
        fishValue - fish's score value .
        fishTime - max time to fish this one.
     
     */
    public void SetValue(int fishValue, float fishTime){
        value = fishValue;
        fTime = fishTime;
    }



}

}