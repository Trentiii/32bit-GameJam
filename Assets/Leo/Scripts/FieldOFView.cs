using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOFView : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public Collider PlayerColl;
    public Camera cam;
    private Plane[] planes;
    private EnemyPatrol enemyScript;
    Hiding h;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerColl = player.GetComponent<Collider>();

        h = player.GetComponent<Hiding>();

        enemyScript = gameObject.GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, PlayerColl.bounds))
        {
            //Debug.Log("Player in range");
            CheckforPlayer();
        }
        else
        {

        }
    }

    void CheckforPlayer()
    {
        RaycastHit hit;


        //Debug.DrawLine(cam.transform.position, Vector3.RotateTowards(cam.transform.position, player.transform.position, Mathf.Deg2Rad * 30, 0), Color.green);

        Debug.DrawRay(cam.transform.position, -(cam.transform.position - player.transform.position), Color.green);

        Vector3.RotateTowards(cam.transform.position, player.transform.position, Mathf.Deg2Rad * 30, 0);

        

        if (!h.isHiding && Physics.Raycast(cam.transform.position, -(cam.transform.position - player.transform.position), out hit, 10))
        {
            if (hit.collider.gameObject.tag != "Wall")
            {
                //Debug.Log("Chase");
                enemyScript.chasing = true;
            }


        }
        else
        {
            //Debug.Log("Chase");
            enemyScript.chasing = false;
        }

    }
}
