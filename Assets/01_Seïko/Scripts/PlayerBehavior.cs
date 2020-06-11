using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_ANDROID || WIN64 || WIN32


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;


#endif

namespace Seiko {
public class PlayerBehavior : MonoBehaviour{

    private Rigidbody2D rb2D;
    private float MoveSpeed = 10f; //The speed at which it accelerate
    private float MaxSpeed = 5f; //The maximal speed of the player
    public static int score {get; private set;} = 0; //Number of Floor the player went through for the camera
    public GameObject myo;


    // Start is called before the first frame update
    void Start(){
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        score = 0;
    }

     /*  Function: Update
        
        Get Inputs to control falling star

        Inputs: 

            * Keyboard.
                * Left - Q
                * Right - D

            * MyoArm Band.
                * Left - WaveIn
                * Right - WaveOut       
    */
    void FixedUpdate(){

        #if UNITY_STANDALONE || UNITY_EDITOR || UNITY_ANDROID || WIN64 || WIN32
            ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
        #endif

        // Keyboard Input
        if(Input.GetKey(KeyCode.Q) && rb2D.velocity.x >= -MaxSpeed){
            rb2D.AddForce(Vector2.left * MoveSpeed);
        }
        if(Input.GetKey(KeyCode.D) && rb2D.velocity.x <= MaxSpeed){
            rb2D.AddForce(Vector2.right * MoveSpeed);
        }


        #if UNITY_STANDALONE || UNITY_EDITOR || UNITY_ANDROID || WIN64 || WIN32
        //Myo armband Input
        if (thalmicMyo.pose == Pose.WaveIn) {
            Debug.Log("Biceps");
            rb2D.AddForce(Vector2.left * MoveSpeed);
            ExtendUnlockAndNotifyUserAction (thalmicMyo);

        } else if (thalmicMyo.pose == Pose.WaveOut) {
            Debug.Log("Triceps");
            rb2D.AddForce(Vector2.right* MoveSpeed);
            ExtendUnlockAndNotifyUserAction (thalmicMyo);

        }


        // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
        // recognized.
        void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo){
            ThalmicHub hub = ThalmicHub.instance;

            if (hub.lockingPolicy == LockingPolicy.Standard) {
                myo.Unlock (UnlockType.Timed);
            }

            myo.NotifyUserAction ();
        }

        #endif

    }

    /*  Function: OnTriggerExit2D
        
        Add score each times ball pass through platform collider area

        Parameters:

            area - Platform collider trigger area.
    */
    private void OnTriggerExit2D(Collider2D area){
        //Each time the player passes between two plateform adds one to the number of floor
        if(area.tag == "CameraTrigger"){
            score++;
        }
    }
}
}
