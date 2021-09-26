using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    NavMeshAgent NavA;
    Transform player;
    PlayerDeath PD;
    public Transform home;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        PD = GameObject.Find("Player").GetComponent<PlayerDeath>();
        NavA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            NavA.destination = player.position;
        }
        else
        {
            NavA.destination = home.position;
        }

        if (PD.playerDead)
        {
            active = false;
            gameObject.transform.position = home.transform.position;
        }
    }
}
