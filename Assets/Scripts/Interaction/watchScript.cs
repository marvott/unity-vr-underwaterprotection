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

public class watchScript : MonoBehaviour
{

    public Text thisText;
    private float ohiIndex;
    public InputAction switchWatch;
    private int currentView;
    private string OHIText = "OHI : 0";
    private string piecesText = "0 Pieces";
    private bool incomingMessage = false;
    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;

    public GameObject SceneManager;

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
        //Set OHI Index to zero
        ohiIndex = 0.0f;
        thisText.text = SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage() + " Pieces";
        currentView = 0;

    }

    /***************************************************************************************************************************
    *Updates score when selected interactable is tagged as "Garbage".
    ***************************************************************************************************************************/
    public void updateScore(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactable.tag == "Garbage")
        {
            ohiIndex += 0.25f;
            SceneManager.GetComponent<SceneManagerScript>().setAmountGarbage(SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage() + 1);
            OHIText = "OHI: " + ohiIndex.ToString();
            piecesText = SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage() + " Pieces";
            updateWatch();
        };
    }

    private void switchWatchView(InputAction.CallbackContext ctx)
    {
        if (currentView == 1)
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
        if (incomingMessage == false)
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

    public void setIncomingMessage(bool value)
    {
        incomingMessage = value;
        if (value == true) thisText.text = "!";
        if(value == false) updateWatch();
    }

}

