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
        if(!sameSpeed)
            SpeedMovement();
    }
    // this is for movement that isn't always equal (faster at angles)
    private void SpeedMovement()
    {
        xVel = Input.GetAxisRaw("Horizontal") * spd * Time.deltaTime;
        zVel = Input.GetAxisRaw("Vertical")   * spd * Time.deltaTime;

        this.transform.position += new Vector3(xVel, 0, zVel);
    }
    // this is for movement that whichever way you go, you'll always go the same speed
    private void sameSpeedMovement()
    {
        xVel = Input.GetAxisRaw("Horizontal") * spd * Time.deltaTime;
        zVel = Input.GetAxisRaw("Vertical") * spd * Time.deltaTime;


        float angle = Mathf.Atan2(xVel, zVel);
        Debug.Log(angle);


        float xVel2 = Mathf.Sin(angle);
        float zVel2 = Mathf.Cos(angle);



        this.transform.position += new Vector3(xVel2, 0, zVel2);
        //Debug.Log(new Vector3(xVel2, 0, zVel2));
    }
    /*
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);      Wanted position
        Vector3 direction = mousePosition - Player.transform.position;                     xxxxxxx

        float angle = Mathf.Atan2(direction.y, direction.x);         angle
        float b2 = Mathf.Sin(angle);
        float a2 = Mathf.Cos(angle);

        offset = new Vector3(a2, b2, -10f);
        if (Peeking)
        {
            Vector3 desiredPosition = Player.transform.position + (lookLength * offset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpd);
            transform.position = smoothedPosition;
        }
    */
}
