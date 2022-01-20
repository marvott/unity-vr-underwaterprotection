using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioClass
{
    private bool hasBeenPlayed, hasToBePlayed;
    private float numberToTrigger;
    private int triggerMode;
    public AudioSource audioSource;
    public GameObject XRRig, mainCamera, righthandController;
    public GameObject sceneManager;
    private AudioClip audioClip;

    //Constructor for Audio class triggered by zPos or amount of garbage.
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

    public AudioClip play()
    {
        if (!hasBeenPlayed)
        {
            if (hasToBePlayed && !audioSource.isPlaying)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                hasBeenPlayed = true;
                return null;
            }
            else
            {
                mainCamera = XRRig.transform.GetChild(0).gameObject;
                foreach (Transform child in mainCamera.transform)
                {
                    if (child.name == "RightHand Controller")
                    {
                        righthandController = child.gameObject;
                    }
                }
                righthandController.GetComponent<hapticImpulse>().custAmplitImpulse(1f, 0.7f);
                hasBeenPlayed = true;
                return audioClip;
            }
        }
        return null;
    }

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
