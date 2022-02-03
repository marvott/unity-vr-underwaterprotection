using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/***************************************************************************************************************************
 *This class adds to a simple audio clip functionalities to see if the audio has been triggered an to play the audio.
 ***************************************************************************************************************************/
public class AudioClass
{
    private bool hasBeenPlayed, hasToBePlayed;
    private float numberToTrigger;
    private int triggerMode;
    public AudioSource audioSource;
    public GameObject XRRig;
    public GameObject sceneManager;
    private AudioClip audioClip;

    /***************************************************************************************************************************
     *Constructor to create an AudioClass.
     *Parameters:
     *AudioSource audioSource  The audioSource the audio should be played at.
     *AudioClip audioClip      The audioClip that should be played.
     *float numberToTrigger    The amount of the specified category that should be reached to trigger the audio.
     *int triggerMode          Defines the category. 0 is z-Position 1 is amount of Garbage 2 is triggered by Start Button.
     *GameObject SceneManager
     *GameObject XRRig
     *bool hasToBePlayed       If true the audio is mandatory. If false the audio is optional.
     ***************************************************************************************************************************/
    public AudioClass(AudioSource audioSource, AudioClip audioClip, float numberToTrigger, int triggerMode, GameObject SceneManager, GameObject XRRig, bool hasToBePlayed )
    {
        this.audioSource = audioSource;
        this.audioClip = audioClip;
        this.numberToTrigger= numberToTrigger;
        this.XRRig = XRRig;
        this.triggerMode = triggerMode;
        this.sceneManager = SceneManager;
        this.hasBeenPlayed = false;
        this.hasToBePlayed = hasToBePlayed;
    }

    /***************************************************************************************************************************
     *Function to play the audio on the given audio Source.
     *Return: 
     *null        The audio is mandatory an directly played.
     *audioClip   The audio is optional and stored in AudioManager
     ***************************************************************************************************************************/
    public AudioClip play()
    {
        if(sceneManager.GetComponent<SceneManagerScript>().getStartTriggered() == false)
        {
            return null;
        }
        if (!hasBeenPlayed)
        {
            if (hasToBePlayed)
            {
                if (audioSource.isPlaying) return null;
                audioSource.clip = audioClip;
                audioSource.Play();
                hasBeenPlayed = true;
                return null;
            }
            else
            {
                hasBeenPlayed = true;
                return audioClip;
            }
        }
        return null;
    }

    /***************************************************************************************************************************
     *Function checks if the audio has been triggered depending on the trigger that has been defined in the constructor.
     *Return:
     *true 
     *false
     ***************************************************************************************************************************/
    public bool isTriggered()
    {
        //Triggered by z position.
        if (triggerMode == 0)
        {
            if (XRRig.transform.position.z > numberToTrigger)
            {
                return true;
            }
        }
        //triggered by amount of garbage.
        if(triggerMode == 1)
        {
            if(sceneManager.GetComponent<SceneManagerScript>().getAmountGarbage() >= numberToTrigger)
            {
                return true;
            }
        }
        //triggered by start button.
        if(triggerMode == 2)
        {
            if (sceneManager.GetComponent<SceneManagerScript>().getStartTriggered())
            {
                return true;
            }
        }
        return false;
    }
}
