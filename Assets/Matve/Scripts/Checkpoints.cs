using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject Cindicator;
    public GameObject player;
    PlayerDeath PD;
    public bool activated;
    public float timer;
    public float maxTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        PD = player.GetComponent<PlayerDeath>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if(timer <= maxTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                activated = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            if (!activated)
            {
                Instantiate(Cindicator);
            }
            PD.checkpoint = gameObject;
            activated = true;
        }
    }
}
