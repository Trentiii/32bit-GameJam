using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltSpawn2 : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public bool spawning;
    public bool canSpawn;
    public float timer;
    public float endTime;
    public int spawnA;
    public int spawnM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            if(spawnA < spawnM)
            {
                
                if(timer <= endTime)
                {
                    timer += Time.deltaTime;
                    canSpawn = false;
                }
                else
                {
                    spawnA += 1;
                    timer = 0;
                    canSpawn = true;
                }
            }
            else
            {
                canSpawn = false;
                spawning = false;
                spawnA = 0;
            }
        }

        if (canSpawn)
        {
            enemy1.transform.position = spawn1.transform.position;
            enemy2.transform.position = spawn2.transform.position;
            enemy3.transform.position = spawn3.transform.position;
        }
    }
}
