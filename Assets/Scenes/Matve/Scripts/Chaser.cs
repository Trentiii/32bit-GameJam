using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    NavMeshAgent NavA;
    Transform player;
    PlayerDeath PD;
    GameObject spawner;
    public Transform home;
    public float chaseTime;
    chaserBeeEngage cbe;
    // Start is called before the first frame update
    void Start()
    {
        PD = GameObject.Find("Player").GetComponent<PlayerDeath>();
        NavA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        spawner = GameObject.Find("SpawnManager");
        cbe = spawner.GetComponent<chaserBeeEngage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chaseTime > 0)
        {
            chaseTime -= Time.deltaTime;
            NavA.destination = player.position;
        }
        else
        {
            NavA.destination = home.position;
        }

        if (PD.playerDead)
        {
            chaseTime = 0;
            cbe.spotted = false;
            gameObject.transform.position = home.transform.position;
        }
    }
}
