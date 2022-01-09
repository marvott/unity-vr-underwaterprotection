using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using System;

public class WhaleInView : MonoBehaviour
{
    public Camera camera;
    public GameObject whale;
    public GameObject XRRig;
    private Vector3 camViewVec, playerPosition, whalePosition, whalePlayerVec;
    private float playerWhaleHighestValue, camHighestValue;
    public float tolerance, triggerDistanceZ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camViewVec = camera.transform.forward;
        playerPosition = XRRig.transform.position;
        whalePosition = whale.transform.position;
        whalePlayerVec = new Vector3(whalePosition.x - playerPosition.x, whalePosition.y - playerPosition.y, whalePosition.z - playerPosition.z);

        playerWhaleHighestValue = whalePlayerVec.y;
        if(Math.Abs(whalePlayerVec.x) > Math.Abs(whalePlayerVec.y))
        {
            playerWhaleHighestValue = whalePlayerVec.x;
        }

        if(Math.Abs(whalePlayerVec.z) > Math.Abs(playerWhaleHighestValue))
        {
            playerWhaleHighestValue = whalePlayerVec.z;
        }

        whalePlayerVec = new Vector3(whalePlayerVec.x / playerWhaleHighestValue, whalePlayerVec.y / playerWhaleHighestValue, whalePlayerVec.z / playerWhaleHighestValue);

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
        Debug.Log("whalePlayerVec " + whalePlayerVec + "camViewVec" + camViewVec);
        Debug.Log("PlayerPosition: " + playerPosition.z + "Objektposition" + whalePosition.z);
        if((whalePlayerVec.x >= camViewVec.x-tolerance && whalePlayerVec.x <= camViewVec.x + tolerance) && (whalePlayerVec.y >= camViewVec.y - tolerance && whalePlayerVec.y <= camViewVec.y + tolerance) && (whalePlayerVec.z >= camViewVec.z - tolerance && whalePlayerVec.z <= camViewVec.z + tolerance) && Math.Abs(playerPosition.z - whalePosition.z) <= triggerDistanceZ)
        {
            whale.GetComponent<PathFollower>().enabled = true;
        }
    }
}