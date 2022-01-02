using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Wird das Script hier überhaupt noch benötigt?
public class LineRendererScript : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 XRRigPosition;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        lineRenderer.SetPosition(1, new Vector3(1000, 0, 0));
    }
}
