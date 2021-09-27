using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDisposal : MonoBehaviour
{
    public GameObject indicator;
    public GameObject nonIND;
    public bool inRange;

    GameObject player;

    [Header("queen")]
    public bool queen = false;
    public GameObject deathblood;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {

                
                
                nonIND.SetActive(true);

                if (queen)
                {
                    transform.GetChild(0).transform.eulerAngles = new Vector3(0, 0, 180);
                    queenDeathEnding.started = true;
                    deathblood.SetActive(true);
                }
                else
                {
                    Destroy(gameObject);
                }
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
            indicator.SetActive(true);
            nonIND.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            nonIND.SetActive(true);
        }
    }
}
