using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***************************************************************************************************************************
 *Plays any AudioClip that is given as a parameter if not another audio is playing
 ***************************************************************************************************************************/
public class Audio : MonoBehaviour
{
    public AudioSource src;

    public void playAudioSource(AudioClip clip)
    { 
        src.clip = clip;
        if (!src.isPlaying)
        {
            src.Play();
        }
    }
}
