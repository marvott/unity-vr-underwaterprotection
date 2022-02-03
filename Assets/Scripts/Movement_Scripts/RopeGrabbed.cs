using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/***************************************************************************************************************************
 *This script provides functions which can be called when a Controller interacts with the rope. 
 ***************************************************************************************************************************/
public class RopeGrabbed : MonoBehaviour
{
    public GameObject SceneManager;
    /***************************************************************************************************************************
    *This function is called directly when an object is selected. If the selected object is the rope the function is executed.
    ***************************************************************************************************************************/
    public void objectSelectionEntered(SelectEnterEventArgs selectEnterEventArgs)
    {
        string objectName = selectEnterEventArgs.interactable.name;
        Debug.Log(objectName);

        if (objectName == "Rope")
        {
            SceneManager.GetComponent<SceneManagerScript>().setRopeIsTouched(true);
        }
        
    }

   /***************************************************************************************************************************
    *This function is called after an object has been selected. When the object is the rope the function is executed.
    ***************************************************************************************************************************/
    public void objectSelectionExit(SelectExitEventArgs selectExitEventArgs)
    {
        string objectName = selectExitEventArgs.interactable.name;

        if(objectName == "Rope")
        {
            Debug.Log("Rope has been untouched!");
            SceneManager.GetComponent<SceneManagerScript>().setRopeIsTouched(false);
        }

    }
}
