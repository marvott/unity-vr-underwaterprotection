using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class WhaleInView : MonoBehaviour
{
    public Camera camera;
    public GameObject whale;
    private Vector3 camViewVec, playerPosition, whalePosition, whalePlayerVec;
    private float playerWhaleHighestValue, camHighestValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camViewVec = camera.transform.forward;
        playerPosition = gameObject.transform.position;
        whalePosition = whale.transform.position;
        whalePlayerVec = new Vector3(whalePosition.x - playerPosition.x, whalePosition.y - playerPosition.y, whalePosition.z - playerPosition.z);
        if(whalePlayerVec.x > whalePlayerVec.y)
        {
            playerWhaleHighestValue = whalePlayerVec.x;
        }

        if(whalePlayerVec.z > playerWhaleHighestValue)
        {
            playerWhaleHighestValue = whalePlayerVec.z;
        }

        whalePlayerVec = new Vector3(whalePlayerVec.x / playerWhaleHighestValue, whalePlayerVec.y / playerWhaleHighestValue, whalePlayerVec.z / playerWhaleHighestValue);

        if (camViewVec.x > camViewVec.y)
        {
            camHighestValue = camViewVec.x;
        }

        if (camViewVec.z > camHighestValue)
        {
            camHighestValue = camViewVec.z;
        }

        camViewVec = new Vector3(camViewVec.x / camHighestValue, camViewVec.y / camHighestValue, camViewVec.z / camHighestValue);
        Debug.Log("whalePlayerVec " + whalePlayerVec + "camViewVec" + camViewVec);
        if((whalePlayerVec.x >= camViewVec.x-0.3 && whalePlayerVec.x <= camViewVec.x + 0.3) && (whalePlayerVec.y >= camViewVec.y - 0.3 && whalePlayerVec.y <= camViewVec.y + 0.3) && (whalePlayerVec.z >= camViewVec.z - 0.3 && whalePlayerVec.z <= camViewVec.z + 0.3))
        {
            whale.GetComponent<PathFollower>().enabled = true;
        }
    }
}