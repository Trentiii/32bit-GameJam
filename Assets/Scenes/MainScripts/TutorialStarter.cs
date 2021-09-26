using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStarter : MonoBehaviour
{
    public GameObject tutorial;
    static bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        if (firstTime)
        {
            tutorial.SetActive(true);
            firstTime = false;
        }
    }
}
