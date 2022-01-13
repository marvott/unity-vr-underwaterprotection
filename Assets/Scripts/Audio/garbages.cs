using System.Collections.Generic;
using UnityEngine;

/***************************************************************************************************************************
 *We are listening for Changes in how many pieces of Garbage have been collected. If the first one has been collected the 
 *first Audio Source is being played
 ***************************************************************************************************************************/

public class garbages : MonoBehaviour
{
    public GameObject SceneManager;
    public List<AudioClip> audioQueue;
    public AudioSource audioSource;
    private bool hasBeenPlayed = false;
    private int amountOfGarbage;
    public bool btnPressed = false; //hier soll eigentlich der knopfdruck nach start abgefragt werden
    private bool tutorialEnd = false;

    void FixedUpdate()
    {
        amountOfGarbage = SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage();

        if (!audioSource.isPlaying)
        {
            if (btnPressed ==true)
            {
                audioSource.clip = audioQueue[0];
                hasBeenPlayed = true;
                btnPressed = false;
                audioSource.PlayOneShot(audioSource.clip);
            }

            if(amountOfGarbage != 0  && hasBeenPlayed==true && tutorialEnd==false) {
                audioSource.clip = audioQueue[1];
                audioSource.PlayOneShot(audioSource.clip);
                tutorialEnd = true;
            }

            if(amountOfGarbage>17 &&amountOfGarbage<=18 && tutorialEnd == true)
            {
                audioSource.clip = audioQueue[2];
                audioSource.PlayOneShot(audioSource.clip);
            }

            if (amountOfGarbage > 30 && amountOfGarbage < 32 && tutorialEnd == true)
            {
                audioSource.clip = audioQueue[3];
                audioSource.PlayOneShot(audioSource.clip);
            }

            if (amountOfGarbage > 50 && amountOfGarbage < 52 && tutorialEnd == true)
            {
                audioSource.clip = audioQueue[4];
                audioSource.PlayOneShot(audioSource.clip);
            }
        }

    }
}
