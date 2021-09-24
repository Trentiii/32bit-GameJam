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

    private void Start()
    {
        indicator = GameObject.FindWithTag("IMG1");
        nonIND = GameObject.FindWithTag("IMG2");
    }
    private void Update()
    {

        if (inRange)
        {
            indicator.SetActive(true);
            nonIND.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                ED.isDead = true;
                
                nonIND.SetActive(true);
            }
        }
        else
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
