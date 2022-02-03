using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/***************************************************************************************************************************
 *This script provides the functionality to give haptic feedback in a specified controller.
 ***************************************************************************************************************************/
public class HapticImpulse : MonoBehaviour
{
    public ActionBasedController controller;
    public float defaultAmplitude;

    /***************************************************************************************************************************
     *Function is called to send haptic feedback with a default amplitude.
     *Parameters: float duration
     ***************************************************************************************************************************/
    public void sendHapticImpulse(float duration)
    {
        controller.SendHapticImpulse(defaultAmplitude ,duration);
    }

    /***************************************************************************************************************************
     *Function is called to send haptic feedback with a custom amplitude.
     *Parameters: float amplitude, float duration
     ***************************************************************************************************************************/
    public void custAmplitImpulse(float amplitude, float duration)
    {

        controller.SendHapticImpulse(amplitude, duration);
    }

    public void setDefaultAmplitude(float dAmplitude)
    {
        defaultAmplitude = dAmplitude;
    }
}
