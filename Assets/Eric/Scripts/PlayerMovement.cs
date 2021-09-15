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
        if (sameSpeed)
            sameSpeedMovement();
        else
            SpeedMovement();
    }

    private void SpeedMovement()
    {
        xVel = Input.GetAxisRaw("Horizontal") * spd * Time.deltaTime;
        zVel = Input.GetAxisRaw("Vertical")   * spd * Time.deltaTime;

        this.transform.position += new Vector3(xVel, 0, zVel);
    }

    private void sameSpeedMovement()
    {
        xVel = Input.GetAxisRaw("Horizontal") * spd * Time.deltaTime;
        zVel = Input.GetAxisRaw("Vertical") * spd * Time.deltaTime;

        float xVel2 = 3f;
        float zVel2 = 3f;



        this.transform.position += new Vector3(xVel2, 0, zVel2);
    }

}
