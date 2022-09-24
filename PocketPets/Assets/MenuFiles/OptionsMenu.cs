using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        //az audiomixer paramétereinek ráhookolása kóddal hogy lehessen mozhatni a sliderrel
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }
}