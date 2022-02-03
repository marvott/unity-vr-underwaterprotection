using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/***************************************************************************************************************************
 *This script spawns garbage objects at random places on the map. When needed any number of garbage objects can be spawned at
 *different places on the map.
 ***************************************************************************************************************************/
public class SpawnObjects : MonoBehaviour
{
    public GameObject obj_prefab;
    private GameObject childObject;
    public GameObject parentObj;
    public int amountToSpawn;
    public float x_start;
    public float x_end;
    public float y;
    public float z_start;
    public float z_end;
    public List<GameObject> PrefabsList;
    

    //Used to spawn objects at the start of the game.
    void Start()
    {
        spawnObject(amountToSpawn);
    }

    /***************************************************************************************************************************
     *Spawns an defined amount of garbage objects as garbage prefabs. The Objects are randomly selected from a list.
     *Parameters: int amount
     ***************************************************************************************************************************/
    public void spawnObject(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(x_start,x_end), y, Random.Range(z_start,z_end));
            childObject = Instantiate(PrefabsList[Random.Range(0,PrefabsList.Count)], pos, Quaternion.identity);

            //Adds Garbage Objects into Parent Folder for better Overview
            childObject.transform.SetParent(parentObj.transform);
            childObject.tag = "Garbage";
        }
    }
}
