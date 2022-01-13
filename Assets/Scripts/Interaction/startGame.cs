using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class startGame : MonoBehaviour
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

    public void startIntroAudio(InputAction.CallbackContext ctx)
    {
        gameObject.active = false;
        sceneManager.GetComponent<SceneManagerScript>().setStartTriggered(true);
    }

    public void permittedAction(InputAction.CallbackContext ctx)
    {
        text.color = Color.red;
        Invoke("permActReleased", 0.25f);
    }

    private void permActReleased()
    {
        text.color = Color.white;
    }
}
