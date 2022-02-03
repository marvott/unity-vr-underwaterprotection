using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

using UnityEngine.UI;

/***************************************************************************************************************************
 *This script provides the functionality to update the watche's score when a garbage object is collected aswell as it sets 
 *the initial value for the watch. In general this script manages the text on the watch.
 ***************************************************************************************************************************/

public class WatchScript : MonoBehaviour
{

    public Text thisText;
    public InputAction switchWatch;
    private int currentView;
    private static string OHIText ;
    private static string piecesText;
    private static bool incomingMessage = false;
    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;
    private Slider progressbarSlider;
    private GameObject progressbar;


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
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        progressbar = GameObject.Find("Progressbar");
        progressbarSlider = progressbar.GetComponent<Slider>();
        piecesText = "Pieces: " + 0;
        OHIText = "OHI: " + 0;
        thisText.text = piecesText;
        currentView = 0; // If 1 then OHIIndex is shown. If 0 then amount of Garbage is shown.
        progressbarSlider.fillRect.GetComponent<Image>().color = new Color(0,255,0);
    }

   /***************************************************************************************************************************
    *Updates score when selected interactable is tagged as "Garbage" and increases OHIIndex and amount of Garbage in SceneManager.
    ***************************************************************************************************************************/
    public void updateScore(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactable.tag == "Garbage")
        {
            SceneManager.GetComponent<SceneManagerScript>().setOHIIndex(SceneManager.GetComponent<SceneManagerScript>().getOHIIndex() + 0.25f);
            SceneManager.GetComponent<SceneManagerScript>().setAmountGarbage(SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage() + 1);
            OHIText = "OHI: " + SceneManager.GetComponent<SceneManagerScript>().getOHIIndex();
            piecesText = "Pieces: " + SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage();
            updateWatch();
        };
    }

    /***************************************************************************************************************************
     *Changes value of current view depending on what is shown on the watch.
     ***************************************************************************************************************************/
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

    /***************************************************************************************************************************
     *This Function is called to display the new text on the watches canvas and update the progressbar. The code is only executed
     *if there isn't a new Message that hasn't been played or rejected yet. 
     ***************************************************************************************************************************/
    public void updateWatch()
    {
         if (incomingMessage == false)
        {
            if (currentView == 1)
            {
                thisText.text = OHIText;
                progressbarSlider. maxValue = 100;
                progressbarSlider.value = SceneManager.GetComponent<SceneManagerScript>().getOHIIndex();

            }
            else if (currentView == 0)
            {
                thisText.text = piecesText;
                progressbarSlider.maxValue = 150;
                progressbarSlider.value = SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage();

            }
        }
    }

    /***************************************************************************************************************************
     *This function is called when a new message is triggered. It is called again when this new message is player or rejected.
     *Parameters: bool value
     ***************************************************************************************************************************/
    public void setIncomingMessage(bool value)
    {
        incomingMessage = value;
        if (value == true)
        {
            thisText.text = "New message!";
            thisText.fontSize = 11;
            thisText.transform.localPosition = new Vector3(-0.0033f, thisText.transform.localPosition.y, thisText.transform.localPosition.z);
            progressbar.SetActive(false);

        }
        if (value == false)
        {
            thisText.fontSize = 14;
            updateWatch();
            thisText.transform.localPosition = new Vector3(0.005f, thisText.transform.localPosition.y, thisText.transform.localPosition.z);
            progressbar.SetActive(true);
        }
    }

    /***************************************************************************************************************************
     *Is called when the player restarts the game.
     ***************************************************************************************************************************/
    public void resetWatch()
    {
        OHIText = "OHI: " + SceneManager.GetComponent<SceneManagerScript>().getOHIIndex();
        piecesText = "Pieces: " + SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage();
        updateWatch();

    }

    /***************************************************************************************************************************
     *Is called when they player tries to play an audio while another audio is still playing.
     ***************************************************************************************************************************/
    public void stillPlaying()
    {
        thisText.text = "Audio still playing!";
        Invoke("resetText", 1);
    }

    /***************************************************************************************************************************
     *Is called to reset the text. "Audio is still playing" is only shown for a short amount auf time.
     ***************************************************************************************************************************/
    public void resetText()
    {
        if(thisText.text == "Audio still playing!")
        {
            thisText.text = "New message! ";
        }
    }

}

