using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject enemy;
    public bool inRange;
    public Image indicator;
    public enemyDies ED;
    private void Update()
    {

        if (inRange)
        {
            indicator.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                indicator.enabled = false;
                ED.isDead = true;
                indicator.enabled = false;
            }
        }
        else
        {
            indicator.enabled = false;
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
