using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



/***************************************************************************************************************************
 *Plays the audio clip if the player reaches a certain point near the end on the rope. 
 ***************************************************************************************************************************/
public class endAudio : MonoBehaviour
{
    public GameObject XRRig;
    private float z_Pos;
    public UnityEvent toBeExec;

    void Update()
    {
        z_Pos = XRRig.transform.position.z;

        if (z_Pos >= 34)
        {
            toBeExec.Invoke();
        }
    }

}
