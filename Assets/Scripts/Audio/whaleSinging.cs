using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/***************************************************************************************************************************
 *This plays an audio clip where a whale is singing. It is detached from the Audio Class 
 *because we need to play multiple other audios at the same time.
 ***************************************************************************************************************************/

public class WhaleSinging : MonoBehaviour
{
    public GameObject XRRig;
    public GameObject Whale_Obj;
    private float player_zPos;
    public float triggerAudioIfPlayerAtZPos;
    public float triggerStopAudioAtZPos;
    private bool hasBeenPlayed = false;
    public AudioSource mainAudioSource;

    void Update()
    {
        //Checks whether the Player has reached a specified position along the rope
        //The value is set in the inspector
        player_zPos = XRRig.transform.position.z;
        if (player_zPos >= triggerAudioIfPlayerAtZPos && hasBeenPlayed == false)
        {
            Whale_Obj.GetComponent<AudioSource>().Play();
            hasBeenPlayed = true;
        }

        //This stops the whale singing when the Player has reached a specified position along the rope
        //otherwise the whale would be singing the whole time and can get quite annoying for some people
        if(player_zPos > triggerStopAudioAtZPos)
        {
            Whale_Obj.GetComponent<AudioSource>().Stop();
        }
    }
}
