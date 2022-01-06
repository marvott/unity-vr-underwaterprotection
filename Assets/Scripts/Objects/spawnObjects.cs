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
    private GameObject childObject;
    public GameObject parentObj;

    //Used to spawn objects at the start of the game.
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnObject(30);
        }

    }

    void Update()
    {


    }

    /***************************************************************************************************************************
     *Spawns an defined amount of garbage objects as garbage prefabs.
     *Parameters: int amount
     ***************************************************************************************************************************/
    public void spawnObject(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //Spawned zufällig Garbage Objecte in der Area
            Vector3 pos = new Vector3(Random.Range(-10, 15), 8f, Random.Range(-10, 60));
            childObject = Instantiate(garbage_prefab, pos, Quaternion.identity);
            //Fügt die ganzen Garbages für eine bessere Übersicht in das übergeordnete leere GameObject.
            childObject.transform.SetParent(parentObj.transform);
            childObject.tag = "Garbage";
        }


    }
}
