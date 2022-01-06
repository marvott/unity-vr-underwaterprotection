using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/***************************************************************************************************************************
 *This script spawns garbage objects at random places on the map. When needed any number of garbage objects can be spawned at
 *different places on the map.
 ***************************************************************************************************************************/
public class spawnObjects : MonoBehaviour
{
    public GameObject garbage_prefab;

    void Start()
    {

    }

    //Used to call spawnObject function when a specified key on the keyboard is pressed.
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            spawnObject(5);
        }

    }

    /***************************************************************************************************************************
     *Spawns an defined amount of garbage objects as garbage prefabs.
     *Parameters: int amount
     ***************************************************************************************************************************/
    public void spawnObject(int amount)
    {
        for(int i = 0; i< amount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-10, 10), 0.2f, Random.Range(5, 20));
            Instantiate(garbage_prefab, pos, Quaternion.identity);
        }
        

    }
}
