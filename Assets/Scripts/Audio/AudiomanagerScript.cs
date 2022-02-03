using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/***************************************************************************************************************************
 *This script is meant to manage the scientist's audio clips. It takes advantage of the functionality of AudioClass and 
 *stores optional messages/audio till they are played or rejected by the player.
 ***************************************************************************************************************************/

public class AudiomanagerScript : MonoBehaviour
{
    private List<AudioClass> audioClasses;
    public AudioSource audioSource;
    public GameObject XRRig, sceneManager;
    private GameObject mainCamera, watch, righthandController;
    public List<AudioClip> audioList;
    private AudioClip savedClip;

    public InputAction playSavedClip;
    public InputAction declineSavedClip;

    private void Awake()
    {
        playSavedClip.Enable();
        playSavedClip.performed += playSaved;
        declineSavedClip.Enable();
        declineSavedClip.performed += declineSaved;
    }

    /***************************************************************************************************************************
     *In start function AudioClasses are created out of the given audio clips. The params in the constructor defines the trigger
     *for the given audio clip.
     ***************************************************************************************************************************/
    private void Start()
    {
        audioClasses = new List<AudioClass>();
        AudioClass audio0 = new AudioClass(audioSource,audioList[0], 0, 2, sceneManager, XRRig, true);
        audioClasses.Add(audio0);
        AudioClass audio1 = new AudioClass(audioSource, audioList[1], 1, 1, sceneManager, XRRig, true);
        audioClasses.Add(audio1);
        AudioClass audio2 = new AudioClass(audioSource, audioList[2], 5, 0, sceneManager, XRRig, false);
        audioClasses.Add(audio2);
        /*AudioClass audio3 = new AudioClass(audioSource, audioList[3], 37, 0, sceneManager, XRRig, false);
        audioClasses.Add(audio3);*/
        AudioClass audio4 = new AudioClass(audioSource, audioList[4], 37, 0, sceneManager, XRRig, false);
        audioClasses.Add(audio4);
        AudioClass audio5 = new AudioClass(audioSource, audioList[5], 15, 0, sceneManager, XRRig, false);
        audioClasses.Add(audio5);
        AudioClass audio6 = new AudioClass(audioSource, audioList[6], 30, 0, sceneManager, XRRig, false);
        audioClasses.Add(audio6);
        AudioClass audio7 = new AudioClass(audioSource, audioList[7], 44, 0, sceneManager, XRRig, true);
        audioClasses.Add(audio7);
        watch = GameObject.Find("WatchText");

        mainCamera = XRRig.transform.GetChild(0).gameObject;
        foreach (Transform child in mainCamera.transform)
        {
            if (child.name == "RightHand Controller")
            {
                righthandController = child.gameObject;
            }
        }
    }

    /***************************************************************************************************************************
     *In update function every AudioClass is checked if it has been triggered. Mandatory audios have a return value of null and
     *are played directly. Optional audios are stored till the player decides to play them.
     ***************************************************************************************************************************/
    private void Update()
    {
        if (sceneManager.GetComponent<SceneManagerScript>().getStartTriggered())
        {
            foreach (AudioClass x in audioClasses)
            {
                if (x.isTriggered())
                {
                    AudioClip playAudio = x.play();
                    if (playAudio != null)
                    {
                        savedClip = playAudio;
                        righthandController.GetComponent<HapticImpulse>().custAmplitImpulse(1f, 0.7f);
                        watch.GetComponent<WatchScript>().setIncomingMessage(true);
                    }
                }
            }
        }
    }

    /***************************************************************************************************************************
     *Function used to play a saved optional audio.
     ***************************************************************************************************************************/
    public void playSaved(InputAction.CallbackContext ctx)
    {
        if (savedClip != null)
        {
            if (audioSource.isPlaying)
            {
                watch.GetComponent<WatchScript>().stillPlaying();
                righthandController.GetComponent<HapticImpulse>().custAmplitImpulse(1f, 0.7f);
                return;
            }
            audioSource.clip = savedClip;
            watch.GetComponent<WatchScript>().setIncomingMessage(false);
            audioSource.Play();
            savedClip = null;
        }

    }

    /***************************************************************************************************************************
     *Function used to reject an optional audio.
     ***************************************************************************************************************************/
    public void declineSaved(InputAction.CallbackContext ctx)
    {
        savedClip = null;
        watch.GetComponent<WatchScript>().setIncomingMessage(false);
    }
}
