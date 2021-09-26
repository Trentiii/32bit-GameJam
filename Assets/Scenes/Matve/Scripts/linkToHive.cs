using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkToHive : MonoBehaviour
{
    public GameObject SpawnM;
    public EnemyPatrol EP;
    public chaserBeeEngage cBE;
    // Start is called before the first frame update
    void Start()
    {
        EP = gameObject.GetComponent<EnemyPatrol>();
        SpawnM = GameObject.FindGameObjectWithTag("SpawnM");
        cBE = SpawnM.GetComponent<chaserBeeEngage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EP.chasing)
        {
            cBE.spotted = true;
        }
        else
        {
            cBE.spotted = false;
        }
        
    }
}
