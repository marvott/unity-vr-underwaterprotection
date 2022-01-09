using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class WhaleScript : MonoBehaviour
{
    public void whaleInViewField()
    {
        gameObject.GetComponent<PathFollower>().enabled = true;
    }
}
