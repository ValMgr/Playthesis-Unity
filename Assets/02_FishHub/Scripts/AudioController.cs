using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static int SoundToPlay = 0;
    private bool VolumeOn = true;
    public AudioSource AudioSource;
    public AudioClip HookInWater;
    public AudioClip HookThrow;
    public AudioClip OutOfWater;
    public AudioClip FishHit;




    private void Start(){
        AudioSource = GetComponent<AudioSource>();
    }

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

    public void PlaySound(AudioClip clip){
        AudioSource.clip = clip;
        AudioSource.Play();
        SoundToPlay = 0;
    }
}
