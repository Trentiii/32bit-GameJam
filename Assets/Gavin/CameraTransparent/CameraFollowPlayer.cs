using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float yOffset;
    public float zOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.zero;
        transform.position = player.position;
        transform.position += new Vector3(0, yOffset, zOffset);
    }
}
