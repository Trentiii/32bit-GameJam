using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarming : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public GameObject enemy;
    public bool swarmActive;
    public int spawnCount;
    public int spawnMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (swarmActive)
        {
            if(spawnCount <= spawnMax)
            {
                spawn();
                spawnCount += spawnCount + 1;
            }
            else
            {
                swarmActive = false;
                spawnCount = 0;
            }
            
        }
    }

    void spawn()
    {
        for (int i = 0; i <= 2; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Instantiate(enemy, spawnPoints[spawnIndex].transform.position, transform.rotation);
        }
    }
}
