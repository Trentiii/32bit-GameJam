using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject enemy;
    public bool inRange;
    public GameObject indicator;
    public GameObject nonIND;
    public enemyDies ED;
    public PlayerDeath pd;

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        pd = player.GetComponent<PlayerDeath>();

        indicator = GameObject.FindWithTag("IMG1");
        nonIND = GameObject.FindWithTag("IMG2");
    }
    private void Update()
    {
        if (inRange && !pd.playerDead)
        {
            indicator.SetActive(true);
            nonIND.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                ED.isDead = true;
                
                nonIND.SetActive(true);
            }
        }
        else if(pd.playerDead || Vector3.Distance(transform.position, player.transform.position) < 5)
        {   
            nonIND.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = false;
        }
    }
}
