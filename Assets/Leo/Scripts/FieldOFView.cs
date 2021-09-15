using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOFView : MonoBehaviour
{
    public GameObject player;
    public Collider PlayerColl;
    public Camera cam;
    private Plane[] planes;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, PlayerColl.bounds))
        {
            Debug.Log("Player in range");
            CheckforPlayer();
        }
        else
        {

        }
    }

    void CheckforPlayer()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.transform.position, transform.forward * 10, Color.green);
        
        if (Physics.Raycast(cam.transform.position, transform.forward, out hit, 10))
        {
            if (hit.collider.gameObject.tag != "Wall")
            {
                Debug.Log("Chase");
            }


        }
        else
        {
            Debug.Log("Chase");
        }
    }
}
