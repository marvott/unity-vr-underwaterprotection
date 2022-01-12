using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class endAudio : MonoBehaviour
{
    public GameObject XRRig;
    private float z_Pos;
    //public UnityEvent toBeExec;
    public AudioSource src;
    public List<AudioClip> audioQueue;


    private void Start()
    {
        src.clip = audioQueue[0];
    }
    void Update()
    {
        z_Pos = XRRig.transform.position.z;


        if (z_Pos >= 34)
        {
            src.Play();
            //toBeExec.Invoke();
        }
    }

}
