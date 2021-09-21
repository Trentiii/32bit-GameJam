using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Dictionary<string, Vector3> Facing = new Dictionary<string, Vector3> {
        { "Forward"       , new Vector3( 0, 0, 1)},
        { "Forward_Right" , new Vector3( 1, 0, 1)},
        { "Right"         , new Vector3( 1, 0, 0)},
        { "Back_Right"    , new Vector3( 1, 0,-1)},
        { "Back"          , new Vector3( 0, 0,-1)},
        { "Back_Left"     , new Vector3(-1, 0,-1)},
        { "Left"          , new Vector3(-1, 0, 0)},
        { "Forward_Left"  , new Vector3(-1, 0, 1)},
    };
    private enum mode { Mouse_Drag, Keyboard_Lerp, Normal};
    [SerializeField] private mode MovementMode;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool sameSpeed = false;

    private float xVel = 0f;
    private float zVel = 0f;
    private float oldZVel = 0f;
    private float oldXVEL = 0f;
    private float spd  = 4f;
    public float smoothing = 3f;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xVel = Input.GetAxisRaw("Horizontal");
        zVel = Input.GetAxisRaw("Vertical");

        oldXVEL = xVel != 0  && zVel != 0 ? xVel : oldXVEL;
        oldZVel = zVel != 0 && xVel != 0 ? zVel : oldZVel;

        switch (MovementMode)
        {
            case mode.Normal:
                Normal();
                break;
            case mode.Keyboard_Lerp:
                Keyboard_Lerp();
                break;
            case mode.Mouse_Drag:
                Mouse_Dragging();
                break;
            default:
                Debug.Log("Movement mode Error (Ask Eric)");
                break;
        }
        Debug.DrawLine(transform.position, transform.position + transform.forward * 3, Color.red);
    }

    private void Keyboard_Lerp()
    {
        if (xVel != 0 || zVel != 0)
        {
            if (sameSpeed)
                this.transform.position += new Vector3(xVel, 0, zVel).normalized * (spd * Time.deltaTime);
            if (!sameSpeed)
                this.transform.position += new Vector3(xVel, 0, zVel) * (spd * Time.deltaTime);


            //Quaternion.LookRotation(new Vector3(0, zVel, 0));

            /*
            float rotZ = Mathf.Atan2(xVel, zVel) * Mathf.Rad2Deg;
            
            float newRotZ = rotZ;
            if (rotZ / Mathf.Abs(rotZ) == -1)
            {
                newRotZ = 360 + rotZ;
            }
            float dif = 360 - newRotZ;
            if(dif < 180)
            {

            }
            */
            //Vector3 smoothedRotation = Vector3.Slerp(currentRotation, new Vector3(0, newRotZ, 0), smoothing * Time.deltaTime);

            Vector3 cR = transform.localRotation.eulerAngles;
            transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(cR), Quaternion.LookRotation(new Vector3(0, zVel, 0)), smoothing * Time.deltaTime);
            //Debug.Log(smoothedRotation);
        }

        //transform.position + new Vector3(xVel, 0, zVel)
    }
    private void Mouse_Dragging() 
    {
        Vector3 point = Vector3.zero;
        //register mouse click
        if (Input.GetMouseButton(1))
        {
            //Get world position of mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                point = raycastHit.point;
                point.y = 1.5f;
                transform.position = point; //move to that point [Will change later]
            }
            
            
        }
        //turn bee
        transform.LookAt(point);


        //move towards point
    }
    private void Controller()  //Need more context
    {
        
    }
    private void Normal()
    {
        if (sameSpeed)
            this.transform.position += new Vector3(xVel, 0, zVel).normalized * (spd * Time.deltaTime);
        if (!sameSpeed)
            this.transform.position += new Vector3(xVel, 0, zVel) * (spd * Time.deltaTime);
    }
    private float CircleLerp(float angle1, float angle2, float smoothing)
    {
        float end = 0f;

        


        return end;
    }
}
