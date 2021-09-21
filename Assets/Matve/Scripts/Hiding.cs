using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public bool isHiding;
    public bool canHide;
    public GameObject IND3;
    public GameObject IND4;
    public GameObject playerModel;
    public PlayerMovement PM;
    public PlayerDeath PD;
    public CharacterController CC;
    // Start is called before the first frame update
    void Start()
    {
        isHiding = false;
        IND3 = GameObject.FindWithTag("IND3");
        IND4 = GameObject.FindWithTag("IND4");
        PM = gameObject.GetComponent<PlayerMovement>();
        PD = gameObject.GetComponent<PlayerDeath>();
        CC = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canHide)
        {
            IND3.SetActive(true);
            IND4.SetActive(false);
            if(Input.GetKeyDown(KeyCode.F))
            {
                if (!isHiding)
                {
                    isHiding = true;
                }
                else
                {
                    isHiding = false;
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
            playerModel.SetActive(false);
            PM.enabled = false;
            CC.enabled = false;
        }
        else
        {
            PD.enabled = true;
            playerModel.SetActive(true);
            PM.enabled = true;
            CC.enabled = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HidingSpot")
        {
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
