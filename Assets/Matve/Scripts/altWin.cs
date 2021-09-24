using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altWin : MonoBehaviour
{
    public bool isDead;
    public GameObject modelDead;
    public GameObject winScreen;
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Instantiate(modelDead, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(winScreen);
            Destroy(gameObject);
        }
    }
}
