using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HexaSpinGrow))]
public class PauseMenu : MonoBehaviour
{
    [HideInInspector]
    public static bool paused = false;

    HexaSpinGrow hsg;

    private void Awake()
    {
        paused = false;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        hsg = GetComponent<HexaSpinGrow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                hsg.spinShrinkStart();
            }
            else
            {
                hsg.spinGrowStart();
            }
        }
  
    }
}
