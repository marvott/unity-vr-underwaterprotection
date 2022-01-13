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
            //Invoke("playVoice", 10); 
        }
        if (Whale_Obj.transform.position.x >= 30)
        {
            mainAudioSource.Stop();
        }
    }
}
