using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

/***************************************************************************************************************************
 *This script is used to Start the game after the player presses the left trigger button. 
 ***************************************************************************************************************************/
public class StartGame : MonoBehaviour
{

    public InputAction start;
    public InputAction permittedActions;
    public GameObject sceneManager;
    private Text text;

    private void OnEnable()
    {
        start.Enable();
        permittedActions.Enable();
        text = gameObject.GetComponent<Text>();
    }

    private void Awake()
    {
        start.performed += startIntroAudio;
        permittedActions.performed += permittedAction;
    }

    /***************************************************************************************************************************
     *Is called to set variables so that the first audio is played aswell as it displays the credits.
     ***************************************************************************************************************************/
    public void startIntroAudio(InputAction.CallbackContext ctx)
    {
        //gameObject.GetComponent<Text>().fontSize = 10;
        gameObject.GetComponent<Text>().text = "Umgesetzt durch Marvin Ottersberg & Micha Wewers, 2022 FH-Kiel";
        sceneManager.GetComponent<SceneManagerScript>().setStartTriggered(true);
        Invoke("disableText", 5f);
    }

   /***************************************************************************************************************************
    *Is when a permitted action is executed before the game is startet.
    ***************************************************************************************************************************/
    public void permittedAction(InputAction.CallbackContext ctx)
    {
        text.color = Color.red;
        Invoke("permActReleased", 0.25f);
    }

   /***************************************************************************************************************************
    *Is called some time after the permitted action has been executed.
    ***************************************************************************************************************************/
    private void permActReleased()
    {
        text.color = Color.white;
    }

   /***************************************************************************************************************************
    *Is called after the player has pressed the left trigger to disable the text.
    ***************************************************************************************************************************/
    private void disableText()
    {
        gameObject.SetActive(false);
    }
    
}
