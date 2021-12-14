using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RopeGrabbed : MonoBehaviour
{
    //Function that is called when an object selection is entered.
    public void objectSelectionEntered(SelectEnterEventArgs selectEnterEventArgs)
    {
        string objectName = selectEnterEventArgs.interactable.name;
        Debug.Log(objectName);

        if(objectName == "Trigger Box 1")
        {
            GameObject world = GameObject.Find("Surrounding");
            world.transform.Translate(0, 0, -1);
        }
        else if (objectName == "Trigger Box 2")
        {
            GameObject world = GameObject.Find("Surrounding");
            world.transform.Translate(0, 0, -3);
        }
        
    }

    public void objectSelectionExit(SelectEnterEventArgs selectEnterEventArgs)
    {

    }
}
