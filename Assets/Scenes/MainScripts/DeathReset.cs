using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathReset : MonoBehaviour
{

    Vector3 startPos;
    Quaternion startRot;

    EnemyPatrol ep;
    enemyDies ed;
    PlayerAttack pa;
    Chaser c;

    GameObject indicator;
    GameObject nonIND;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;

        pa = GetComponent<PlayerAttack>();
        ep = GetComponent<EnemyPatrol>();
        ed = GetComponent<enemyDies>();
        c = GetComponent<Chaser>();

        indicator = GameObject.FindWithTag("IMG1");
        nonIND = GameObject.FindWithTag("IMG2");
    }

    public void deathReseter()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<NavMeshAgent>().enabled = true;

        if (c == null)
        {
            GetComponent<FieldOFView>().enabled = true;
            GetComponent<FOVVisualization>().enabled = true;
            GetComponent<EnemyPatrol>().enabled = true;

            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
        }

        if (ed.isDead)
        {
            ed.isDead = false;
            ed.stopped = false;
            Destroy(ed.body);
            ed.deathEffect.SetActive(false);

            if(ep != null)
                ep.enabled = true;
        }

        transform.position = startPos;
        transform.rotation = startRot;

        if (ep != null)
        {
            ep.chasing = false;
            pa.inRange = false;
        }

        if (c != null)
        {
            c.chaseTime = 0;
        }

        indicator.SetActive(true);
        nonIND.SetActive(true);

        GetComponent<PlayerAttack>().enabled = true;
    }    
}
