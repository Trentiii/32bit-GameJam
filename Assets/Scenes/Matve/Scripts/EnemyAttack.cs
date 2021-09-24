using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    PlayerDeath PD;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PD = player.GetComponent<PlayerDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            PD.playerDead = true;
        }
    }
}
