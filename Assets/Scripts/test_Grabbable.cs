using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.UI;

/***************************************************************************************************************************
 *This script provides the functionality to update the watche's score when a garbage object is collected aswell as it sets 
 *the initial value for the watch.
 ***************************************************************************************************************************/

public class test_Grabbable : MonoBehaviour { 

    public Text thisText;
    private int value;

    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;
    //TODO: Müssen hier die auskommentierten Zeilen die wirkliches Code Zeilen sind noch entfernt werden?
    void Start()
    {
        //Sets the initial value of the watch to express the state when no garbage is collected.
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        //grabInteractable.onActivate.AddListener(SetGreen);
        value = 0;
        thisText.text = value.ToString() + " Pieces"; //thisText.GetComponent<Text>().text 

    }

    //The function updates the watche's score when garbage is collected.
    public void updateScore(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactable.tag == "Garbage") {
            value += 1;
            thisText.text = value.ToString() + " Pieces";
        };
    }


}
