using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using PathCreation.Examples;

/***************************************************************************************************************************
 *This script enables the Player to restart or end the game when he/she has reached a specified  point along the route and 
 *is supposed to be finished playing. 
 ***************************************************************************************************************************/

public class EndGame : MonoBehaviour
{
    public InputAction restartGame;
    public InputAction endGame;
    public GameObject sceneManager;
    public Text pieces_text;
    public Text ohi_text;
    public GameObject XRRig;
    public GameObject Whale;
    public int zTreshhold;
    public GameObject parentObjects;
    public List<GameObject> prefabsList;
    private SpawnObjects spawnObjects;
    private float z_Pos;

    private void OnEnable()
    {
        restartGame.Enable();
        endGame.Enable();
    }

    private void Awake()
    {
           restartGame.performed += restartGameFunc;
           endGame.performed += endGameFunc;
    }

    //This function restarts the Game and resets all values
    public void restartGameFunc(InputAction.CallbackContext ctx)
    {
        if (z_Pos > zTreshhold)
        {
            sceneManager.GetComponent<SceneManagerScript>().setAmountGarbage(0);
            sceneManager.GetComponent<SceneManagerScript>().setOHIIndex(0);
            XRRig.transform.position = new Vector3(0.6f,0.91f,-2.36f);
            spawnObjects = GameObject.Find("SpawningObjects").GetComponent<SpawnObjects>();
            GameObject.Find("WatchText").GetComponent<WatchScript>().resetWatch();
            spawnObjects.parentObj = parentObjects;
            spawnObjects.PrefabsList = prefabsList;
            spawnObjects.x_start = -1.8f;
            spawnObjects.x_end = 2.5f;
            spawnObjects.y = 0.6f;
            spawnObjects.z_start = -5f;
            spawnObjects.z_end = 45f;
            spawnObjects.spawnObject(150 - sceneManager.GetComponent<SceneManagerScript>().getAmountGarbage());


        }
    }

    //This function ends the game
    public void endGameFunc(InputAction.CallbackContext ctx)
    {

        if (z_Pos > zTreshhold)
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }

    //This gets the players current position and sets the values on the wooden frame at the end
    //pieces are the amount of garbage the player has collected and the ohi-index
    private void Update()
    {
        z_Pos = XRRig.transform.position.z;
        pieces_text.text = sceneManager.GetComponent<SceneManagerScript>().getAmountGarbage() +"";
        ohi_text.text = sceneManager.GetComponent<SceneManagerScript>().getOHIIndex()*100 + "";


    }
}
