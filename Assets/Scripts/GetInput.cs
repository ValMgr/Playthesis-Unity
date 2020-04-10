using UnityEngine;
using System.Collections;

#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_ANDROID || WIN64 || WIN32


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class GetInput : MonoBehaviour {

    public GameObject myo;

    private void Update() {

        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

        if (thalmicMyo.pose == Pose.Fist) {
            Debug.Log("Double contraction");
            ExtendUnlockAndNotifyUserAction (thalmicMyo);

        } else if (thalmicMyo.pose == Pose.WaveIn) {
            Debug.Log("Biceps");
            ExtendUnlockAndNotifyUserAction (thalmicMyo);

        } else if (thalmicMyo.pose == Pose.WaveOut) {
            Debug.Log("Triceps");
            ExtendUnlockAndNotifyUserAction (thalmicMyo);

        } else if (thalmicMyo.pose == Pose.DoubleTap) {
            Debug.Log("Double tap");
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


}

#endif