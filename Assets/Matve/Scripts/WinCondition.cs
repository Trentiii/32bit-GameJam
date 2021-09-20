using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool hasWon;
    bool didWin;
    public GameObject youWin;
    public GameObject player;
    PlayerMovement PM;
    // Start is called before the first frame update
    void Start()
    {
        PM = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon)
        {
            Instantiate(youWin);
            PM.enabled = false;
            hasWon = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hasWon = true;
            
        }
    }
}
