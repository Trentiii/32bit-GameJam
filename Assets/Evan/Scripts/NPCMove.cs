using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMove : MonoBehaviour
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
