using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queenKill : MonoBehaviour
{
    public GameObject enemy;
    public bool inRange;
    public GameObject indicator;
    public GameObject nonIND;
    public altWin AW;

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

                AW.isDead = true;

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
        if (other.tag == "Player")
        {
            inRange = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
}
