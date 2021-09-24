using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDisposal : MonoBehaviour
{
    public GameObject indicator;
    public GameObject nonIND;
    public bool inRange;

    GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Player");

        indicator = GameObject.FindWithTag("IMG1");
        nonIND = GameObject.FindWithTag("IMG2");
    }
    private void Update()
    {

        if (inRange)
        {
            indicator.SetActive(true);
            nonIND.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {

                
                
                nonIND.SetActive(true);
                Destroy(gameObject);
            }
        }
        else if(Vector3.Distance(transform.position, player.transform.position) < 5)
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
