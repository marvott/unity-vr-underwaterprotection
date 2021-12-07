using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class spawnObjects : MonoBehaviour
{
    public GameObject garbage_prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            spawnObject(5);
        }

    }

    public void spawnObject(int amount)
    {
        for(int i = 0; i< amount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-10, 10), 0.2f, Random.Range(5, 20));
            Instantiate(garbage_prefab, pos, Quaternion.identity);
        }
        

    }
}
