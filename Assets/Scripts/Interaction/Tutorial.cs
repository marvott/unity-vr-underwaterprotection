using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private float timer = 0.0f;
    void Start()
    {
        this.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            this.GetComponent<SphereCollider>().enabled = true;
        }
    }
}
