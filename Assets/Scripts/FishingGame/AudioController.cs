using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static int SoundToPlay = 0;
    private bool VolumeOn = true;
    private AudioSource AudioSource;
    public AudioClip BaitInWater;
    public AudioClip HookThrow;
    public AudioClip OutOfWater;
    public AudioClip FishHit;




    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            VolumeOn = !VolumeOn;
        }


        if (VolumeOn)
        {
            AudioSource.volume = 0.5f;
        }
        else
        {
            AudioSource.volume = 0;
        }

        switch (SoundToPlay)
        {
            case 1:
                PlaySound(HookThrow);
                break;

            case 2:
                PlaySound(BaitInWater);
                break;

            case 3:
                PlaySound(OutOfWater);
                break;

            case 4:
                PlaySound(FishHit);
                break;

            default:
                break;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.Play();
        SoundToPlay = 0;
    }
}
