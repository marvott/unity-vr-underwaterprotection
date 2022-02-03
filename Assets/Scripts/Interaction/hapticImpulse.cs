using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticImpulse : MonoBehaviour
{
    public ActionBasedController controller;
    public float defaultAmplitude;
    
    public void sendHapticImpulse(float duration)
    {
        controller.SendHapticImpulse(defaultAmplitude ,duration);
    }

    public void custAmplitImpulse(float amplitude, float duration)
    {

        controller.SendHapticImpulse(amplitude, duration);
    }

    public void setDefaultAmplitude(float dAmplitude)
    {
        defaultAmplitude = dAmplitude;
    }
}
