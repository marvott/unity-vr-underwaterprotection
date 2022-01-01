using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.UI;

public class test_Grabbable : MonoBehaviour { 

    //Text der Anzeige bekommen
    public Text thisText;
    private int amountGarbage;
    private int ohiIndex;
    public float period = 0.0f;

    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        //grabInteractable.onActivate.AddListener(SetGreen);
        //Wert der Anzeige auf Null setzen
        amountGarbage = 0;
        ohiIndex = 0;
        thisText.text = amountGarbage.ToString() + " Pieces"; //thisText.GetComponent<Text>().text 

    }

    //Score auf der uhr updaten, wenn ein Garbage Object gegrabbed wird
    public void updateScore(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactable.tag == "Garbage") {
            amountGarbage += 1;
            thisText.text = amountGarbage.ToString() + " Pieces";
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
       
        
        
        period += Time.deltaTime;
    }


}
