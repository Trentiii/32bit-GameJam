using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool debugDeath;
    public bool playerDead;
    PlayerMovement PM;
    public GameObject model1;
    public GameObject model2;
    public GameObject checkpoint;
    public float timer;
    public float respawntime;
    public GameObject player;

    public GameObject enemyParent;
    public GameObject deathEffect;

    public GameObject deathMenu;

    public bool queen = false;

    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PlayerMovement>();
        playerDead = false;

        if (queen)
        {
            checkpoint = GameObject.Find("SpawnPoint");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.J) && debugDeath)
        {
            playerDead = true;
        }

        if (playerDead)
        {
            deathMenu.SetActive(true);
            deathEffect.SetActive(true);
            PM.enabled = false;
            model1.SetActive(false);
            //model2.SetActive(true);
            
            if (timer <= respawntime)
            {
                timer = 0;
                //timer += Time.deltaTime;
            }
            if (timer >= respawntime)
            {

                player.transform.position = checkpoint.transform.position;
                deathEffect.SetActive(false);

                for (int i = 0; i < enemyParent.transform.childCount; i++)
                {
                    enemyParent.transform.GetChild(i).GetComponent<DeathReset>().deathReseter();
                }

                GameObject[] chasers = GameObject.FindGameObjectsWithTag("ChaserBee");

                for (int i = 0; i < chasers.Length; i++)
                {
                    chasers[i].GetComponent<DeathReset>().deathReseter();
                }

                GameObject[] bodies = GameObject.FindGameObjectsWithTag("Body");

                for (int i = 0; i < bodies.Length; i++)
                {
                    Destroy(bodies[i]);
                }

                playerDead = false;
                timer = 0;
            }

            
        }
        else
        {
            PM.enabled = true;
            model1.SetActive(true);
            model2.SetActive(false);
            deathMenu.SetActive(false);
        }

        

    }
}
