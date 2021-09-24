using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyDies : MonoBehaviour
{
    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public bool stopped = false;

    public GameObject modelDead;
    public GameObject deathEffect;

    [HideInInspector]
    public GameObject body;

    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead && !stopped)
        {
            stopped = true;

            Instantiate(modelDead, gameObject.transform.position, Quaternion.identity);

            deathEffect.SetActive(true);

            GetComponent<BoxCollider>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<FieldOFView>().enabled = false;
            GetComponent<FOVVisualization>().enabled = false;
            GetComponent<EnemyPatrol>().enabled = false;

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
