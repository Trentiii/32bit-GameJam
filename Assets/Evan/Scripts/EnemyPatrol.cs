using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour
{
    [Header("Partol Points")]
    [SerializeField]
    int wantedChildIndex = 0;

    Transform patrolPointParentParent;
    Transform patrolPointParent;

    [SerializeField]
    int currentPoint = 0; //Holds current wanted loop

    [SerializeField]
    bool firstHalf = true; //Holds if first half a patrol loop

    GameObject[] patrolPoint; //Holds all patrol points

    [Header("Movement Mode (Pick one)")]
    [SerializeField]
    [Tooltip("If true moves back and forth through the point array")]
    bool backForthMovement = true;

    [SerializeField]
    [Tooltip("Moves through the aray 0 to max repeatedly")]
    bool circleMovement = false;

    [HideInInspector]
    public Transform player;

    [Header("Misc.")]
    //[HideInInspector]
    public bool chasing = false;

    [SerializeField]
    bool drone = false;

    bool resetNeeded = false; //Holds if patrol reset is needed
    

    //Referencess
    NavMeshAgent navA;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        patrolPointParentParent = GameObject.Find("PatrolPointParent").transform;
        patrolPointParent = patrolPointParentParent.GetChild(wantedChildIndex);

        SetPatrolPoints();

        navA = GetComponent<NavMeshAgent>();
        navA.destination = patrolPoint[currentPoint].transform.position;

        //Logs errors for movement settings
        if (!backForthMovement && !circleMovement)
        {
            Debug.LogError("No movement mode selected");
        }
        else if (backForthMovement && circleMovement)
        {
            Debug.LogError("To many movement modes selected");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //If chasing
        if (chasing)
        {
            if (drone)
            {

                navA.speed = 0;

                Vector3 direction = (player.transform.position - transform.position).normalized;

                Quaternion lookRotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3);
            }
            else
            {
                navA.speed = 6.3f;
            }

            //Set destintation to player
            navA.destination = player.position;
            resetNeeded = true;
        }
        else
        {
            if (drone)
            {
                navA.speed = 3.5f;
            }
            else
            {
                navA.speed = 5.8f;
            }

            //If reset needeed
            if (resetNeeded)
            {
                //Find closetest patrol point
                currentPoint = 0;
                float distance = 9999;

                for (int i = 0; i < patrolPoint.Length; i++)
                {
                    if (Vector3.Distance(patrolPoint[i].transform.position, transform.position) < distance)
                    {
                        distance = Vector3.Distance(patrolPoint[i].transform.position, transform.position);
                        currentPoint = i;
                    }
                }

                resetNeeded = false;
            }


            //Set current point to postition
            navA.destination = patrolPoint[currentPoint].transform.position;
            

            //If enemy has reached patrol point
            if (Vector3.Distance(transform.position, patrolPoint[currentPoint].transform.position) <= 0.5)
            {
                //If moving through the points in the first half
                if (firstHalf)
                {
                    //If havent reached end
                    if (currentPoint < patrolPoint.Length - 1)
                    {
                        currentPoint++; //Move to next point
                    }
                    else if (backForthMovement) //If moving back and forth
                    {
                        currentPoint--; //Move to next point back
                        firstHalf = false; //Flip first half bool
                    }
                    else //If moving in circle
                    {
                        currentPoint = 0; //Go back to start
                    }
                }
                else
                {
                    //If havent reached start
                    if (currentPoint != 0)
                    {
                        currentPoint--; //Move to next point
                    }
                    else
                    {
                        currentPoint++; //Move to next point back
                        firstHalf = true; //Flip first half bool
                    }
                }
            }
        }
    }

    void SetPatrolPoints()
    {
        patrolPoint = new GameObject[patrolPointParent.childCount];

        for (int i = 0; i < patrolPoint.Length; i++)
        {
            patrolPoint[i] = patrolPointParent.GetChild(i).gameObject;
        }
    }
}
