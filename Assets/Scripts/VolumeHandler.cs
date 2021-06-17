using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeHandler : MonoBehaviour
{
    public AudioMixer masterAudio;

    public void SetLevel(float sliderValue)
    {
        masterAudio.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20);
    }

    
}
