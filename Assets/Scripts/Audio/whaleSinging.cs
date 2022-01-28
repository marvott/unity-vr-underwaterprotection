using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class whaleSinging : MonoBehaviour
{
    public GameObject XRRig;
    public GameObject Whale_Obj;
    private float player_zPos;
    public float triggerAudioIfPlayerAtZPos;
    public float triggerStopAudioAtZPos;
    private bool hasBeenPlayed = false;
    public AudioSource mainAudioSource;
    //public UnityEvent playVoiceAfterDiscovery;

    void Update()
    {
        player_zPos = XRRig.transform.position.z;

        if (player_zPos >= triggerAudioIfPlayerAtZPos && hasBeenPlayed == false)
        {
            Whale_Obj.GetComponent<AudioSource>().Play();
            hasBeenPlayed = true;
        }

        if(player_zPos > triggerStopAudioAtZPos)
        {
            Whale_Obj.GetComponent<AudioSource>().Stop();
        }
    }
}
