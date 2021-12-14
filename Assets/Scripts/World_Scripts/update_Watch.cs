using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;



public class update_Watch : MonoBehaviour
    {
        public Text thisText;

        private int value;
        // Start is called before the first frame update
        void Start()
        {
            value = 0;

            thisText.text = value.ToString() + " Points"; //thisText.GetComponent<Text>().text 

        }

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current.pKey.wasPressedThisFrame)
            {
                value += 1;
                thisText.text = value.ToString() + " Points";
            }
        }
    }

