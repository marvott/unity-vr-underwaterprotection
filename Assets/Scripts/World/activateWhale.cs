using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

/***************************************************************************************************************************
 *This function is called, when the player looked directly at the whale.
 *The Path-Follower is then being enabled and the whale swims along the path
 ***************************************************************************************************************************/

public class ActivateWhale: MonoBehaviour
{
    public void whaleInViewField()
    {
        gameObject.GetComponent<PathFollower>().enabled = true;
    }
}

