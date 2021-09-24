using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public bool isHiding;
    public bool canHide;
    GameObject IND3;
    GameObject IND4;
    public GameObject playerModel;
    PlayerMovement PM;
    PlayerDeath PD;
    CharacterController CC;
    ParticleSystem ps;

    Transform hidingSpot;
    Vector3 oldPos;
    Quaternion oldRot;

    // Start is called before the first frame update
    void Start()
    {
        isHiding = false;
        IND3 = GameObject.FindWithTag("IND3");
        IND4 = GameObject.FindWithTag("IND4");
        PM = gameObject.GetComponent<PlayerMovement>();
        PD = gameObject.GetComponent<PlayerDeath>();
        CC = gameObject.GetComponent<CharacterController>();
        ps = transform.GetChild(3).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canHide)
        {
            IND3.SetActive(true);
            IND4.SetActive(false);
            if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            {
                if (!isHiding)
                {
                    isHiding = true;
                    ps.Play();

                    oldPos = transform.position;
                    oldRot = transform.rotation;
                }
                else
                {
                    isHiding = false;
                    ps.Play();

                    transform.position = oldPos;
                    transform.rotation = oldRot;
                }
                
            }


        }
        else
        {
            IND3.SetActive(false);
            IND4.SetActive(true);
            isHiding = false;
        }

        if (isHiding)
        {
            PD.enabled = false;
            transform.position = new Vector3(hidingSpot.position.x, hidingSpot.position.y, hidingSpot.position.z);
            transform.rotation = Quaternion.Euler(-hidingSpot.rotation.eulerAngles.x, hidingSpot.rotation.eulerAngles.y - 180, hidingSpot.rotation.eulerAngles.z);
            PM.enabled = false;
            CC.enabled = false;
        }
        else
        {
            PD.enabled = true;
            PM.enabled = true;
            CC.enabled = true;
        }
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HidingSpot")
        {
            hidingSpot = other.transform.parent;
            canHide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HidingSpot")
        {
            canHide = false;
        }
    }
}
