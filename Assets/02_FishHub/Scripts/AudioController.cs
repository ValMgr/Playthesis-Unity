using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FishHub {
public class AudioController : MonoBehaviour{

    // Group: Variables
    public static int SoundToPlay = 0;
    private bool VolumeOn = true;
    public AudioSource AudioSource;

    // Group: AudioClip
    public AudioClip HookInWater;
    public AudioClip HookThrow;
    public AudioClip OutOfWater;
    public AudioClip FishHit;


    // Group: Functions

    private void Start(){
        AudioSource = GetComponent<AudioSource>();
    }

    /* Function: Update

        Mute sound with M

    */
    private void Update(){

        if (Input.GetKeyDown(KeyCode.M)){
            VolumeOn = !VolumeOn;
        }


        if (VolumeOn){
            AudioSource.volume = 0.5f;
        }
        else{
            AudioSource.volume = 0;
        }

    }


    /* Function: PlaySound

        Play Audioclip

        Parameters: 
            clip - Audioclip to play

    */
    public void PlaySound(AudioClip clip){
        AudioSource.clip = clip;
        AudioSource.Play();
        SoundToPlay = 0;
    }
}

}