using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using System;
using UnityEngine.Events;

public class ObjectInFieldOfView : MonoBehaviour
{
    public Camera camera;
    public GameObject XRRig;
    private Vector3 camViewVec, playerPosition, objectPosition, objectPlayerVec;
    private float playerObjectHighestValue, camHighestValue;
    public float tolerance, triggerDistanceZ;

    public UnityEvent toBeExecuted;


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

        objectPlayerVec = new Vector3(objectPlayerVec.x / playerObjectHighestValue, objectPlayerVec.y / playerObjectHighestValue, objectPlayerVec.z / playerObjectHighestValue);

        camHighestValue = camViewVec.y;
        if (Math.Abs(camViewVec.x) > Math.Abs(camViewVec.y))
        {
            camHighestValue = camViewVec.x;
        }

        if (Math.Abs(camViewVec.z) > Math.Abs(camHighestValue))
        {
            camHighestValue = camViewVec.z;
        }

        camViewVec = new Vector3(camViewVec.x / camHighestValue, camViewVec.y / camHighestValue, camViewVec.z / camHighestValue);
        //Debug.Log("whalePlayerVec " + objectPlayerVec + "camViewVec" + camViewVec);
        //Debug.Log("PlayerPosition: " + playerPosition.z + "Objektposition" + objectPosition.z);
        if ((objectPlayerVec.x >= camViewVec.x - tolerance && objectPlayerVec.x <= camViewVec.x + tolerance) && (objectPlayerVec.y >= camViewVec.y - tolerance && objectPlayerVec.y <= camViewVec.y + tolerance) && (objectPlayerVec.z >= camViewVec.z - tolerance && objectPlayerVec.z <= camViewVec.z + tolerance) && Math.Abs(playerPosition.z - objectPosition.z) <= triggerDistanceZ)
        {
            executeNow();
        }
    }

    private void executeNow()
    {
        toBeExecuted.Invoke();
    }
}