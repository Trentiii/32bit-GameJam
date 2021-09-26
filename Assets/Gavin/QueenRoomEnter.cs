using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QueenRoomEnter : MonoBehaviour
{
    bool canEnter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canEnter)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canEnter)
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "QueenEnding")
        {
            canEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "QueenEnding")
        {
            canEnter = false;
        }
    }
}
