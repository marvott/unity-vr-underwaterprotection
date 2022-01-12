using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public List<AudioClip> audioQueue;

    public void playAudioSource(AudioClip clip)
    {
        AudioSource src = new AudioSource();        
        src.clip = clip;
        Debug.Log("terasfd");
        if (!src.isPlaying)
        {
            src.Play();
        }
    }
}
