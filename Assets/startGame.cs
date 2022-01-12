using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class startGame : MonoBehaviour
{

    public InputAction start;

    private void OnEnable()
    {
        start.Enable();
    }

    private void Awake()
    {
        start.performed += startIntroAudio;
    }

    public void startIntroAudio(InputAction.CallbackContext ctx)
    {
        gameObject.active = false;
    }
}
