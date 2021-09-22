using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(320, 240, Screen.fullScreen);
    }
}
