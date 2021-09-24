using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToHome : MonoBehaviour
{
    public GameObject home;
    EnemyPatrol EP;
    public float timer;
    public float warptime;
    // Start is called before the first frame update
    void Start()
    {
        EP = gameObject.GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!EP.chasing)
        {
            if(timer <= warptime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                gameObject.transform.position = home.transform.position;
            }
        }
        else
        {
            timer = 0;
        }
    }
}
