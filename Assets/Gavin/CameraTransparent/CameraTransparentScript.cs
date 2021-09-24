using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparentScript : MonoBehaviour
{
    public Transform player;
    private GameObject currentHiddenWall;

    public Material visibleWallMat;
    public Material invisibleWallMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, player.position - transform.position);
        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo, Vector3.Distance(transform.position, player.position));

        Debug.DrawRay(transform.position, player.position - transform.position);
        

        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.tag == "Wall")
            {
                /*
                 * Use if we can make transparency happen
                 * if(currentHiddenWall.gameObject != hitInfo.collider.gameObject)
                {
                    currentHiddenWall.GetComponent<MeshRenderer>().material = visibleWallMat;
                }

                currentHiddenWall = hitInfo.collider.gameObject;

                MeshRenderer wall = currentHiddenWall.GetComponent<MeshRenderer>();
                wall.material = invisibleWallMat;*/

                if (currentHiddenWall != null && currentHiddenWall.gameObject != hitInfo.collider.gameObject)
                {
                    currentHiddenWall.GetComponent<MeshRenderer>().enabled = true;
                }

                currentHiddenWall = hitInfo.collider.gameObject;

                MeshRenderer wall = currentHiddenWall.GetComponent<MeshRenderer>();

                wall.enabled = false;

            }
        }

        
    }
}
