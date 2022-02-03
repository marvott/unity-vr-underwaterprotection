using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************************************************************************
 *This script includes the functionality to destroy the game object the script is attached to. It is used to destroy the
 *garbage which is collected by the player to give the player the illusion he absorbed the garbage with the sphere in his 
 *right hand.
 ***************************************************************************************************************************/

public class DestroyGarbage : MonoBehaviour
{
    /*********************************************************************************************************************
     *Function is called to destroy the garbage which is collected.
     **********************************************************************************************************************/
    public void destroy()
    {
        Destroy(gameObject);
    }
}
