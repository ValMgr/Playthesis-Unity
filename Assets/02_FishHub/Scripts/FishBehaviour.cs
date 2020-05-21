using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FishBehaviour : MonoBehaviour {
    

    private FishManager FishManager;


    private bool hasTarget = false;
    private bool isTurning = false;

    private Vector3 currentWP;
    private Vector3 lastWP;

    [SerializeField]
    [Range(0f, 10f)]
    private float speed = 2f;
    public int value;
    private bool baited;
    private bool hooked;

    // Get FishManager script
    private void Start() {
        FishManager = transform.parent.transform.parent.GetComponent<FishManager>();
    }

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
        // if hook reached call Fishing method from HookBehaviour scripts
        if(transform.position == currentWP && baited){
           
            if(!hooked){
                GameObject.Find("Hook").GetComponent<HookBehaviour>().Fishing();
            }
            hooked = true;
        }
    }


    // Find a new random position and give a random speed
    // RandomPosition is a public method from FishManager.cs
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

    // Rotate fish to lookat wp when swimming toward it
    private void RotateFish(Vector3 waypoint, float currentspeed){

        float RotSpeed = currentspeed * Random.Range(1f, 3f);
        Vector3 LookAt = waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookAt), RotSpeed * Time.deltaTime);

    }

    // method call from HookBehaviour script, give hook gameobject as new wp
    public void Baited(Vector3 HookPosition){
        currentWP = new Vector3(HookPosition.x, HookPosition.y -.25f, HookPosition.z);
        speed = Random.Range(0.5f, 1.5f);
        baited = true;
    }

    // public method call from HookBehaviour script to release fish and get new wp if hooking failed
    public void ReleaseFish(){
        hooked = false;
        hasTarget = false;
        baited = false;
    }

}
