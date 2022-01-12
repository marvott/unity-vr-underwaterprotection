using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************************************************************************
 *We are listening for Changes in how many pieces of Garbage have been collected. If the first one has been collected the 
 *first Audio Source is being played
 ***************************************************************************************************************************/

public class firstPieceOfGarbage : MonoBehaviour
{
    public GameObject SceneManager;
    public List<AudioClip> audioQueue;
    public AudioSource audioSource;


    private int amountOfGarbage;
    // Start is called before the first frame update
    void Start()
    {
        //Play audio at start of the game
        audioSource.clip = audioQueue[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        amountOfGarbage = SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage();

        if (!audioSource.isPlaying)
        {
            if (amountOfGarbage >=1 && amountOfGarbage <2)
            {
                audioSource.clip = audioQueue[1];
                audioSource.Play();
            }
        }
    }
}
