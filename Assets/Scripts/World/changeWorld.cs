using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***************************************************************************************************************************
 *Spawns Fish in dependency of how much garbage has been collected.
 ***************************************************************************************************************************/
public class changeWorld : MonoBehaviour
{
    public GameObject SceneManager;
    public GameObject obj_prefab;
    private GameObject childObject;
    public GameObject parentObj;
    public float x_start;
    public float x_end;
    public float y_start;
    public float y_end;
    public float z_start;
    public float z_end;
    public int initialFishGroups;
    public int amountOfNewSpawningFishgroups;
    public int spawnFishgroupEveryXGarbageCollected;
    private int amountOfCollectedGarbage;
    private int oldAmountGarbageValue = 0;
    public GameObject m_EmissiveObject;

    float emissiveIntensity = 10;
    Color emissiveColor = Color.green;


    void Start()
    {
        //Instantiates new FishGroups at Start
        spawnFishGroup(initialFishGroups);

    }

    void FixedUpdate()
    {
        amountOfCollectedGarbage = SceneManager.GetComponent<SceneManagerScript>().getAmountGarbage();

        //Checks if a new Garbage has been collected and if the amount of collected garbage is a multiple of X (spawnFishgroupEveryXGarbageCollected).
        //So if spawnFishGroup... is equal to 5, every 5 collected Garbages a new Fishgroup is instantiated
        if(amountOfCollectedGarbage % spawnFishgroupEveryXGarbageCollected == 0 && amountOfCollectedGarbage > oldAmountGarbageValue)
        {
            spawnFishGroup(amountOfNewSpawningFishgroups);
            oldAmountGarbageValue = amountOfCollectedGarbage;

            m_EmissiveObject.GetComponent<Renderer>().material.SetColor("_EmissiveColor", emissiveColor * emissiveIntensity);
        }
        
    }

    /***************************************************************************************************************************
  *Spawns a defined amount of objects 
  *Parameters: int amount
  ***************************************************************************************************************************/
    public void spawnFishGroup(int amount)
    {
        for (int i = 0; i< amount; i++) { 
            Vector3 pos = new Vector3(Random.Range(x_start, x_end), Random.Range(y_start,y_end), Random.Range(z_start, z_end));
            childObject = Instantiate(obj_prefab, pos, Quaternion.Euler(0, Random.Range(0, 180f), 0));

            //Adds Garbage Objects into Parent Folder for better Overview
            childObject.transform.SetParent(parentObj.transform);
            childObject.tag = "FishGroup";
            //TODO: Hier wollte Marvin noch mal drauf schauen!
            /*if ( i%3==0)
            {
                childObject.GetComponent<Rigidbody>().velocity = transform.forward * 0.1f;
            }else
            {
                childObject.GetComponent<Rigidbody>().velocity = -transform.forward * 0.1f;
            }*/
        }
    }
}
