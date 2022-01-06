using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.UI;

/***************************************************************************************************************************
 *This script provides the functionality to update the score on the watch when a garbage object is collected aswell as it sets 
 *the initial value for the watch.
 ***************************************************************************************************************************/

public class test_Grabbable : MonoBehaviour { 

    public Text thisText;
    public int amountGarbage;
    private float ohiIndex;
    private float period = 0.0f;

    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;

    public GameObject SceneManager;

    void Start()
    {
        //Sets the initial value of the watch to express the state when no garbage is collected.
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        amountGarbage = 0;
        ohiIndex = 0.0f;
        thisText.text = amountGarbage.ToString() + " Pieces";

    }

    /***************************************************************************************************************************
    *Updates score when selected interactable is tagged as "Garbage".
    ***************************************************************************************************************************/
    public void updateScore(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactable.tag == "Garbage") {
            amountGarbage += 1;
            ohiIndex += 0.25f;
        };
    }

    public void Update()
    {
        if ( period <5)
        {
            thisText.text = "OHI: "+ ohiIndex.ToString() ;
            
        }
        else if(period>5 && period< 10)
        {
            thisText.text = amountGarbage.ToString() + " Pieces";
        }
        else
        {
            period = 0;
        }


        SceneManager.GetComponent<SceneManagerScript>().setAmountGarbage(amountGarbage);
        period += Time.deltaTime;
    }


}
