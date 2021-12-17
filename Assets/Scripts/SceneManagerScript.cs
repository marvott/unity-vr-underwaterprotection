using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public static bool ropeIsTouched;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isRopeTouched()
    {
        return ropeIsTouched;
    }

    public void setRopeIsTouched(bool _ropeIsTouched)
    {
        ropeIsTouched = _ropeIsTouched;
    }
}
