using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.UI;

public class test_Grabbable : MonoBehaviour { 

    //Text der Anzeige bekommen
    public Text thisText;
    private int value;

    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        //grabInteractable.onActivate.AddListener(SetGreen);
        //Wert der Anzeige auf Null setzen
        value = 0;
        thisText.text = value.ToString() + " Pieces"; //thisText.GetComponent<Text>().text 

    }

    //Score auf der uhr updaten, wenn ein Garbage Object gegrabbed wird
    public void updateScore(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactable.tag == "Garbage") {
            value += 1;
            thisText.text = value.ToString() + " Pieces";
        };
    }


}
