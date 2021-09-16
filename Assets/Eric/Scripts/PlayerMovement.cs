using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xVel = 0f;
    public float zVel = 0f;
    public float spd  = 4f;

    public bool sameSpeed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xVel = Input.GetAxisRaw("Horizontal");
        zVel = Input.GetAxisRaw("Vertical");

        if (sameSpeed)
            this.transform.position += new Vector3(xVel, 0, zVel).normalized * (spd * Time.deltaTime);
        if (!sameSpeed)
            this.transform.position += new Vector3(xVel, 0, zVel) * (spd * Time.deltaTime);
    }
}
