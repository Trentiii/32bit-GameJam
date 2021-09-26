using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaserBeeEngage : MonoBehaviour
{
    public bool spotted;
    public GameObject chasers;
    Chaser chacha;
    // Start is called before the first frame update
    void Start()
    {


        chacha = chasers.GetComponent<Chaser>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spotted)
        {
            chacha.active = true;
        }
    }
}
