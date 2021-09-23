using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltSpawnManager : MonoBehaviour
{
    public bool spawnNow;
    GameObject[] spawners;
    public GameObject enemy;
    public int spawnCount;
    public int spawnMax;
    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("SpawnPoints");
        spawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnNow)
        {
            if(spawnCount <= spawnMax)
            {
                spawnCount++;
                spawn();
            }
            else
            {
                spawnNow = false;
                spawnCount = 0;
            }
        }
    }

    void spawn()
    {
        foreach(GameObject SpawnPoints in spawners)
        {
            Instantiate(enemy, spawners[0].transform.position, spawners[0].transform.rotation);
        }
    }
}
