using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparentScript : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.position - player.position);
        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo, Vector3.Distance(transform.position, player.position));

        if(hitInfo.collider != null)
        {

        }

        if(hitInfo.collider != null && hitInfo.collider.gameObject.tag == "Wall")
        {
            print("Player Hidden");
        }
    }
}
