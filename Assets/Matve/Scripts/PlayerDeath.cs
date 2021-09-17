using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool debugDeath;
    public bool playerDead;
    playerMovement PM;
    public GameObject model1;
    public GameObject model2;
    public GameObject checkpoint;
    public float timer;
    public float respawntime;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        PM = GetComponent<playerMovement>();
        playerDead = false;
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
            
            PM.enabled = false;
            model1.SetActive(false);
            model2.SetActive(true);
            
            if (timer <= respawntime)
            {
                timer += Time.deltaTime;
            }
            if (timer >= respawntime)
            {
                playerDead = false;
                timer = 0;
            }
            player.transform.position = checkpoint.transform.position;
        }
        else
        {
            PM.enabled = true;
            model1.SetActive(true);
            model2.SetActive(false);
        }

        

    }
}
