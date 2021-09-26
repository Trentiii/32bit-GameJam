using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkToHive : MonoBehaviour
{
    public GameObject SpawnM;
    public EnemyPatrol EP;
    public chaserBeeEngage cBE;

    GameObject[] otherDrones;
    EnemyPatrol[] ep;

    public int zone = 0;

    // Start is called before the first frame update
    void Start()
    {
        EP = gameObject.GetComponent<EnemyPatrol>();
        SpawnM = GameObject.FindGameObjectWithTag("SpawnM");
        cBE = SpawnM.GetComponent<chaserBeeEngage>();

        otherDrones = GameObject.FindGameObjectsWithTag("zone" + zone);

        ep = new EnemyPatrol[otherDrones.Length];
        for (int i = 0; i < otherDrones.Length; i++)
        {
            ep[i] = otherDrones[i].GetComponent<EnemyPatrol>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EP.chasing)
        {
            cBE.spotted[zone] = true;
        }
        else
        {
            bool allOff = true;

            for (int i = 0; i < ep.Length; i++)
            {
                if (ep[i].chasing == true)
                {
                    allOff = false;
                    break;
                }
            }

            if(allOff)
                cBE.spotted[zone] = false;
        }
        
    }
}
