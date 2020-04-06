using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;


public class PlayerBehavior : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public float MoveSpeed = 5f; //The speed at which it accelerate
    public float MaxSpeed = 5f; //The maximal speed of the player
    private Vector2 VectorHorizontal = new Vector2(1.0f, 0.0f);
    public static int CamCount = 0; //Number of Floor the player went through for the camera

    public GameObject myo;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;
        CamCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

        // Keyboard Input
        if(Input.GetKey(KeyCode.Q) && rb2D.velocity.x >= -MaxSpeed){
            rb2D.AddForce(VectorHorizontal * -MoveSpeed);
        }
        if(Input.GetKey(KeyCode.D) && rb2D.velocity.x <= MaxSpeed){
            rb2D.AddForce(VectorHorizontal * MoveSpeed);
        }

        //Myo armband Input
       if (thalmicMyo.pose == Pose.WaveIn) {
            Debug.Log("Biceps");
            rb2D.AddForce(VectorHorizontal * -MoveSpeed);
            ExtendUnlockAndNotifyUserAction (thalmicMyo);

        } else if (thalmicMyo.pose == Pose.WaveOut) {
            Debug.Log("Triceps");
            rb2D.AddForce(VectorHorizontal * MoveSpeed);
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



    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        //Each time the player passes between two plateform adds one to the number of floor
        if(other.tag == "CameraTrigger")
        {
            CamCount++;
        }
    }
}
