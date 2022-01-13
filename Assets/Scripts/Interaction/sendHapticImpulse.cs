using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class sendHapticImpulse : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public float amplitude, duration;
    
    public void sendLeftImpulse()
    {
        leftController.SendHapticImpulse(amplitude, duration);
    }

    public void sendRightImpulse()
    {
        rightController.SendHapticImpulse(amplitude, duration);
    }
}
