using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour
{
	public GameObject player;
    public float distance = 10f;
	void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + distance, player.transform.position.z);
    }
}
