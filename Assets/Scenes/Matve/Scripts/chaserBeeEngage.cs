using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaserBeeEngage : MonoBehaviour
{
    [HideInInspector]
    public bool[] spotted = new bool[8];
    public GameObject[] chasers;
    Chaser[] chacha;
    // Start is called before the first frame update
    void Start()
    {

        chasers = GameObject.FindGameObjectsWithTag("ChaserBee");

        chacha = new Chaser[chasers.Length];
        for (int i = 0; i < chasers.Length; i++)
        {
            chacha[i] = chasers[i].GetComponent<Chaser>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < chacha.Length; i++)
        {
            if (spotted[chacha[i].zone])
                chacha[i].chaseTime = 8;
        }
    }
}
