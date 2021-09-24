using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum mode { Mouse_Drag, Keyboard_Lerp, Normal, Weird};
    [SerializeField] private mode MovementMode;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool sameSpeed = false;
    Rigidbody rb;
    public float mouseSpeed = 0f;
    private float xVel = 0f;
    private float zVel = 0f;
    private float oldZVel = 0f;
    private float oldXVEL = 0f;
    [SerializeField]private float spd  = 5f;
    [SerializeField]private float mouseDragHeight  = 5f;
    public float smoothing = 3f;
    [SerializeField]private Camera mainCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

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
            case mode.Keyboard_Lerp:
                Keyboard_Lerp();
                break;
            case mode.Mouse_Drag:
                Mouse_Dragging();
                break;
            case mode.Weird:
                Weird();
                break;
            default:
                Debug.LogError("Movement mode Error (Ask Eric)");
                break;
        }
        Debug.DrawLine(transform.position, transform.position + transform.forward * 3, Color.red);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Keyboard_Lerp()
    {
        if (xVel != 0 || zVel != 0)
        {
            if (sameSpeed)
                this.transform.position += new Vector3(xVel, 0, zVel).normalized * (spd * Time.deltaTime);
            if (!sameSpeed)
                this.transform.position += new Vector3(xVel, 0, zVel) * (spd * Time.deltaTime);

            float rotZ = Mathf.Atan2(xVel, zVel) * Mathf.Rad2Deg;
            float smoothedRotation = Mathf.LerpAngle(transform.localRotation.eulerAngles.y, rotZ, smoothing * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, smoothedRotation, 0));

        }

        
    }
    private void Weird()
    {
        if (xVel != 0 || zVel != 0)
        {
            if (sameSpeed)
                this.transform.position += new Vector3(xVel, 0, zVel).normalized * (spd * Time.deltaTime);
            if (!sameSpeed)
                this.transform.position += new Vector3(xVel, 0, zVel) * (spd * Time.deltaTime);

            float rotZ = Mathf.Atan2(xVel, zVel) * Mathf.Rad2Deg;


            Vector3 smoothedRotation = Vector3.LerpUnclamped(transform.localRotation.eulerAngles, new Vector3(0, rotZ, 0), smoothing * Time.deltaTime);

            transform.rotation = Quaternion.Euler(smoothedRotation);
            //Debug.Log(smoothedRotation);
        }

        //transform.position + new Vector3(xVel, 0, zVel)
    }
    private void Mouse_Dragging() 
    {
        Vector3 point = Vector3.zero;
        float distance = 0f;
        //register mouse click
        if (Input.GetMouseButton(1))
        {
            //Get world position of mouse
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                Debug.Log("Name of obj: " + raycastHit.collider.gameObject);
                point = raycastHit.point;
                point.y = mouseDragHeight;
                distance = Mathf.Sqrt(Mathf.Pow(point.z - transform.position.z, 2) + Mathf.Pow(point.x - transform.position.x, 2));
                transform.position = Vector3.Lerp(transform.position, point, (mouseSpeed/distance) * Time.deltaTime); //move to that point [Will change later]
                transform.LookAt(point);
            }
            
            
        }
        //turn bee
        


        //move towards point
    }
    private void Controller()
    {
        if (sameSpeed)
            this.transform.position += new Vector3(xVel, 0, zVel).normalized * (spd * Time.deltaTime);
        if (!sameSpeed)
            this.transform.position += new Vector3(xVel, 0, zVel) * (spd * Time.deltaTime);
        float rotZ = Mathf.Atan2(xVel, zVel) * Mathf.Rad2Deg;
        float smoothedRotation = Mathf.LerpAngle(transform.localRotation.eulerAngles.y, rotZ, smoothing * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, smoothedRotation, 0));
    }
    private float CircleLerp(float angle1, float angle2, float smoothing)
    {
        float end = 0f;

        


        return end;
    }
}
