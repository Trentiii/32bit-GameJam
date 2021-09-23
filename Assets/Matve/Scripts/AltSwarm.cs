using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltSwarm : MonoBehaviour
{
    public bool debug;
    public int sc;
    public int sm = 1;
    public GameObject manager;
    AltSpawnManager ASM;
    public bool spotted;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("SpawnM");
        ASM = manager.GetComponent<AltSpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!debug)
        {
            if (spotted)
            {
                ASM.spawnNow = true;
            }
            else
            {
                ASM.spawnNow = false;
            }
        }
        else
        {
            if(spotted && sc <= sm)
            {
                ASM.spawnNow = true;
                sc++;
            }
            else
            {
                ASM.spawnNow = false;
            }
        }
        
    }
}
