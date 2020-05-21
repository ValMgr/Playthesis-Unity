using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeikoAudioController : MonoBehaviour
{
    private AudioSource AudioSource;
    private bool VolumeOn = true;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
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
    }
}
