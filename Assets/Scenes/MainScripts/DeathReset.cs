using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathReset : MonoBehaviour
{

    Vector3 startPos;
    Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void deathReseter()
    {
        transform.position = startPos;
        transform.rotation = startRot;
    }    
}
