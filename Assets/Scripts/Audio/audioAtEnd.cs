using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



/***************************************************************************************************************************
 *Plays the audio clip if the player reaches a certain point near the end on the rope. 
 ***************************************************************************************************************************/
public class audioAtEnd : MonoBehaviour
{
    public GameObject XRRig;
    private float z_Pos;
    public UnityEvent toBeExec;
    private bool hasBeenPlayed = false;

    void Update()
    {
        z_Pos = XRRig.transform.position.z;
        if (z_Pos >= 34 && hasBeenPlayed == false)
        {
            hasBeenPlayed = true;
            toBeExec.Invoke();
        }
    }
}
