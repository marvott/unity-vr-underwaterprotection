using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using System;
using UnityEngine.Events;

/***************************************************************************************************************************
 *This script provides the functionally to detect wether the player looks at an specific object or not. A tolerance 
 *so that the player does not need to look directly at the object is taken into account. 
 ***************************************************************************************************************************/
public class ObjectInFieldOfView : MonoBehaviour
{
    public Camera camera;
    public GameObject XRRig;
    private Vector3 camViewVec, playerPosition, objectPosition, objectPlayerVec;
    private float playerObjectHighestValue, camHighestValue;
    public float tolerance, triggerDistanceZ;

    public UnityEvent toBeExecuted;


    /***************************************************************************************************************************
     *In update function the vector between the player and object are constantly compared to the view vector of the camera.
     *If both match the player looks at the given object.
     ***************************************************************************************************************************/
    void Update()
    {
        camViewVec = camera.transform.forward;
        playerPosition = XRRig.transform.position;
        objectPosition = gameObject.transform.position;
        objectPlayerVec = new Vector3(objectPosition.x - playerPosition.x, objectPosition.y - playerPosition.y, objectPosition.z - playerPosition.z);

        playerObjectHighestValue = objectPlayerVec.y;
        if (Math.Abs(objectPlayerVec.x) > Math.Abs(objectPlayerVec.y))
        {
            playerObjectHighestValue = objectPlayerVec.x;
        }

        if (Math.Abs(objectPlayerVec.z) > Math.Abs(playerObjectHighestValue))
        {
            playerObjectHighestValue = objectPlayerVec.z;
        }

        objectPlayerVec = new Vector3(objectPlayerVec.x / playerObjectHighestValue, objectPlayerVec.y / playerObjectHighestValue, objectPlayerVec.z / playerObjectHighestValue); //To make both vectors comparable the related unit vector of objectPlayerVec is computed.

        camHighestValue = camViewVec.y;
        if (Math.Abs(camViewVec.x) > Math.Abs(camViewVec.y))
        {
            camHighestValue = camViewVec.x;
        }

        if (Math.Abs(camViewVec.z) > Math.Abs(camHighestValue))
        {
            camHighestValue = camViewVec.z;
        }

        camViewVec = new Vector3(camViewVec.x / camHighestValue, camViewVec.y / camHighestValue, camViewVec.z / camHighestValue); //To make both vectors comparable the related unit vector of camViewVec is computed.
        //Debug.Log("whalePlayerVec " + objectPlayerVec + "camViewVec" + camViewVec);
        //Debug.Log("PlayerPosition: " + playerPosition.z + "Objektposition" + objectPosition.z);
        if ((objectPlayerVec.x >= camViewVec.x - tolerance && objectPlayerVec.x <= camViewVec.x + tolerance) && (objectPlayerVec.y >= camViewVec.y - tolerance && objectPlayerVec.y <= camViewVec.y + tolerance) && (objectPlayerVec.z >= camViewVec.z - tolerance && objectPlayerVec.z <= camViewVec.z + tolerance) && Math.Abs(playerPosition.z - objectPosition.z) <= triggerDistanceZ)
        {
            executeNow();
        }
    }

    /***************************************************************************************************************************
     *executeNow executes a specified function when the player look at the given object. 
     ***************************************************************************************************************************/
    private void executeNow()
    {
        toBeExecuted.Invoke();
    }
}