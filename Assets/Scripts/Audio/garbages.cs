using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/***************************************************************************************************************************
 *We are listening for Changes in how many pieces of Garbage have been collected. If the first one has been collected the 
 *first Audio Source is being played
 ***************************************************************************************************************************/

public class garbages : MonoBehaviour
{
    private List<AudioClass> audioClasses;
    public AudioSource audioSource;
    public GameObject XRRig, sceneManager, watch;
    public List<AudioClip> audioList;
    private AudioClip savedClip;

    public InputAction playSavedClip;

    private void Awake()
    {
        playSavedClip.Enable();
        playSavedClip.performed += playSaved;
    }

    private void Start()
    {
        audioClasses = new List<AudioClass>();
        AudioClass audio0 = new AudioClass(audioSource,audioList[0], 0, 2, sceneManager, XRRig, true);
        audioClasses.Add(audio0);
        AudioClass audio1 = new AudioClass(audioSource, audioList[1], 1, 1, sceneManager, XRRig, true);
        audioClasses.Add(audio1);
        AudioClass audio2 = new AudioClass(audioSource, audioList[2], 5, 0, sceneManager, XRRig, false);
        audioClasses.Add(audio2);
        AudioClass audio3 = new AudioClass(audioSource, audioList[3], 8, 0, sceneManager, XRRig, false);
        audioClasses.Add(audio3);
        AudioClass audiowal = new AudioClass(audioSource, audioList[6], 13, 0, sceneManager, XRRig, false);
        audioClasses.Add(audiowal);
        //AudioClass audio4 = new AudioClass(audioSource, audioList[4], 27, 0, sceneManager, XRRig, false);
        //audioClasses.Add(audio4);
        AudioClass audio5 = new AudioClass(audioSource, audioList[5], 34, 0, sceneManager, XRRig, true);
        audioClasses.Add(audio5);
        watch = GameObject.Find("WatchView");
    }

    private void FixedUpdate()
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
                        watch.GetComponent<watchScript>().setIncomingMessage(true);
                    }
                }
            }
        }
    }

    public void playSaved(InputAction.CallbackContext ctx)
    {
        if (savedClip != null)
        {
            audioSource.clip = savedClip;
            watch.GetComponent<watchScript>().setIncomingMessage(false);
            audioSource.Play();
            savedClip = null;
        }

    }

}
