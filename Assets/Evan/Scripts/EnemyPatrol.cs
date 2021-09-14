using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour
{

   [SerializeField]
   GameObject[] partolPoint = new GameObject[5];

    int currentPoint = 0;

    NavMeshAgent navA;

    // Start is called before the first frame update
    void Start()
    {
        navA = GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        navA.destination = partolPoint[currentPoint].transform.position;


    }
}
