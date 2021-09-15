using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public float timer;
    public float timetillfade = 3;
    public bool checkpointready;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           if (timer <= timetillfade)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        
    }
}
