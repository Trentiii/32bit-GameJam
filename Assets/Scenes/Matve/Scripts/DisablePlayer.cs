using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour
{
    public GameObject player;
    PlayerMovement PM;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PM = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        PM.enabled = false;
    }
}
