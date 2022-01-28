using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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

    public void restartGameFunc(InputAction.CallbackContext ctx)
    {
        if (z_Pos > zTreshhold)
        {
            sceneManager.GetComponent<SceneManagerScript>().setAmountGarbage(0);
            XRRig.transform.position = new Vector3(0.6f,0.91f,-2.36f);
            Whale.transform.position = new Vector3(-38f, 1f, -49f);
        }
    }

    public void endGameFunc(InputAction.CallbackContext ctx)
    {

        if (z_Pos > zTreshhold)
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }


    private void Update()
    {
        z_Pos = XRRig.transform.position.z;
        pieces_text.text = sceneManager.GetComponent<SceneManagerScript>().getAmountGarbage() +"";
        ohi_text.text = sceneManager.GetComponent<SceneManagerScript>().getOHIIndex()*100 + "";


    }
}
