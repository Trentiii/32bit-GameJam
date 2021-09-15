using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour
{

    [SerializeField]
    GameObject[] partolPoint = new GameObject[5]; //Holds all patrol points

    [SerializeField]
    [Tooltip("If true moves back and forth through the point array")]
    bool backForthMovement = true;

    [SerializeField]
    [Tooltip("Moves through the aray 0 to max repeatedly")]
    bool circleMovement = false;

    public Transform player;

    //[HideInInspector]
    public bool chasing = true;


    bool firstHalf = true; //Holds if frist half a patrol loop
    int currentPoint = 0; //Holds current wanted loop

    //Referencess
    NavMeshAgent navA;

    // Start is called before the first frame update
    void Start()
    {
        navA = GetComponent<NavMeshAgent>();
        navA.destination = partolPoint[currentPoint].transform.position;

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
        if (chasing)
        {
            navA.destination = player.position;
        }
        else
        {
            navA.destination = partolPoint[currentPoint].transform.position;

            //If enemy has reached patrol point
            if (Vector3.Distance(transform.position, partolPoint[currentPoint].transform.position) <= 0.5)
            {
                //If moving through the points in the first half
                if (firstHalf)
                {
                    //If havent reached end
                    if (currentPoint < partolPoint.Length - 1)
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
}
