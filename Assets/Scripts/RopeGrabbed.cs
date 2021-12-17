using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RopeGrabbed : MonoBehaviour
{
    public GameObject SceneManager;
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
        else if (objectName == "Rope")
        {
            Debug.Log("Rope has been touched!");
            SceneManager.GetComponent<SceneManagerScript>().setRopeIsTouched(true);
        }
        
    }

    public void objectSelectionExit(SelectExitEventArgs selectExitEventArgs)
    {
        string objectName = selectExitEventArgs.interactable.name;
        Debug.Log(objectName);

        if(objectName == "Rope")
        {
            Debug.Log("Rope has been untouched!");
            SceneManager.GetComponent<SceneManagerScript>().setRopeIsTouched(false);
        }

    }
}
