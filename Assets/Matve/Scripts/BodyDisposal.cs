using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDisposal : MonoBehaviour
{
    public GameObject indicator;
    public GameObject nonIND;
    public bool inRange;
    // Start is called before the first frame update
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
            if (Input.GetKeyDown(KeyCode.E))
            {

                
                
                nonIND.SetActive(true);
                Destroy(gameObject);
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
