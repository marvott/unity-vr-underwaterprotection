using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

using UnityEngine.UI;

/***************************************************************************************************************************
 *This script provides the functionality to update the watche's score when a garbage object is collected aswell as it sets 
 *the initial value for the watch.
 ***************************************************************************************************************************/

public class test_Grabbable : MonoBehaviour { 

    public Text thisText;
    private int amountGarbage;
    private float ohiIndex;
    public float period = 0.0f;
    public InputAction switchWatch;
    private int currentView;
    private string OHIText = "OHI : 0";
    private string piecesText = "0 Pieces";
    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;

    private void OnEnable()
    {
        switchWatch.Enable();
    }

    private void Awake()
    {
       switchWatch.performed += switchWatchView;
    }

    void Start()
    {
        //Sets the initial value of the watch to express the state when no garbage is collected.
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        //Wert der Anzeige auf Null setzen
        amountGarbage = 0;
        ohiIndex = 0.0f;
        thisText.text = amountGarbage.ToString() + " Pieces";
        currentView = 0;

    }

    /***************************************************************************************************************************
    *Updates score when selected interactable is tagged as "Garbage".
    ***************************************************************************************************************************/
    public void updateScore(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactable.tag == "Garbage") {
            amountGarbage += 1;
            ohiIndex += 0.25f;
            OHIText = "OHI: " + ohiIndex.ToString();
            piecesText = amountGarbage.ToString() + " Pieces";
            updateWatch();
        };
    }

    public void switchWatchView(InputAction.CallbackContext ctx)
    {
        if(currentView == 1)
        {
            currentView = 0;

        }
        else if (currentView == 0)
        {
            currentView = 1;
        }
        updateWatch();
        Debug.Log("Watch View changed");
    }

    public void updateWatch()
    {
        if (currentView == 1)
        {
            thisText.text = OHIText;

        }
        else if (currentView == 0)
        {
            thisText.text = piecesText;
        }
    }


}
