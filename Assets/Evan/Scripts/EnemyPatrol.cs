using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour
{

    [SerializeField]
    Transform patrolPointParent;

    GameObject[] patrolPoint; //Holds all patrol points

    [SerializeField]
    [Tooltip("If true moves back and forth through the point array")]
    bool backForthMovement = true;

    [SerializeField]
    [Tooltip("Moves through the aray 0 to max repeatedly")]
    bool circleMovement = false;

    public Transform player;

    //[HideInInspector]
    public bool chasing = true;

    bool resetNeeded = false; //Holds if patrol reset is needed
    bool firstHalf = true; //Holds if frist half a patrol loop
    int currentPoint = 0; //Holds current wanted loop

    //Referencess
    NavMeshAgent navA;

    // Start is called before the first frame update
    void Start()
    {

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
            //Set destintation to player
            navA.destination = player.position;
            resetNeeded = true;
        }
        else
        {
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
