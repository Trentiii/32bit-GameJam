using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawn : MonoBehaviour
{
    public EnemyPatrol EP;
    public AltSpawn2 AS2;
    public GameObject spawnManager;
    public bool thething;
    public float timer;
    public float coolDown;
    // Start is called before the first frame update
    void Start()
    {
        EP = gameObject.GetComponent<EnemyPatrol>();
        spawnManager = GameObject.FindWithTag("SpawnM");
        AS2 = spawnManager.GetComponent<AltSpawn2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EP.chasing)
        {
            thething = true;


        }
        
    }
}