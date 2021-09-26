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
    Hiding h;
    public float speed = 7;
    float currentSpeed;
    BoxCollider bc;

    public int zone = 1;

    // Start is called before the first frame update
    void Start()
    {
        PD = GameObject.Find("Player").GetComponent<PlayerDeath>();
        bc = transform.GetChild(0).GetComponent<BoxCollider>();
        NavA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        spawner = GameObject.Find("SpawnManager");
        cbe = spawner.GetComponent<chaserBeeEngage>();
        h = player.GetComponent<Hiding>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (chaseTime > 0 && !h.isHiding)
        {
            bc.enabled = true;

            chaseTime -= Time.deltaTime;
            NavA.destination = player.position;

            currentSpeed = speed;
            NavA.speed = currentSpeed;
        }
        else if (chaseTime > 0 && h.isHiding)
        {
            bc.enabled = true;

            chaseTime -= Time.deltaTime;
            NavA.destination = player.position;

            currentSpeed -= 4 * Time.deltaTime;
            NavA.speed = currentSpeed;
        }
        else
        {
            NavA.destination = home.position;

            bc.enabled = false;

            currentSpeed = speed;
            NavA.speed = currentSpeed;

            if ((NavA.destination - transform.position).magnitude < 0.1f)
            {
                gameObject.transform.position = home.transform.position;

                transform.rotation = Quaternion.Slerp(transform.rotation, home.transform.rotation, Time.deltaTime * 3);
            }
        }

        if (PD.playerDead)
        {
            chaseTime = 0;
            cbe.spotted[zone] = false;

            currentSpeed = speed;
            NavA.speed = currentSpeed;

            gameObject.transform.position = home.transform.position;
            gameObject.transform.rotation = home.transform.rotation;
        }
    }
}
