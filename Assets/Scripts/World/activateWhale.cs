using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

/***************************************************************************************************************************
 *This script is used to activate the whale.
 ***************************************************************************************************************************/

public class ActivateWhale: MonoBehaviour
{
    /***************************************************************************************************************************
     *This function is called when the player looks at the whale. 
     ***************************************************************************************************************************/
    public void whaleInViewField()
    {
        gameObject.GetComponent<PathFollower>().enabled = true;
    }
}

