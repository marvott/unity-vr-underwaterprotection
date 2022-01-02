using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***************************************************************************************************************************
 *The SceneManagerScript is meant to be attached to a SceneManager Object. Their should not be more then one SceneManager
 *object in every scene. The SceneManager object manages the global variables used by multiple objects in the scene. It aswell
 *provides functions that can be called by any other script.
 ***************************************************************************************************************************/
public class SceneManagerScript : MonoBehaviour
{
    public static bool ropeIsTouched; //Variable is true, when player touches the rope.

    public bool isRopeTouched()
    {
        return ropeIsTouched;
    }

    public void setRopeIsTouched(bool _ropeIsTouched)
    {
        ropeIsTouched = _ropeIsTouched;
    }
}
