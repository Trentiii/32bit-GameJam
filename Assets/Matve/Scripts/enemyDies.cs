using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDies : MonoBehaviour
{
    public bool isDead;
    public GameObject modelDead;
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Instantiate(modelDead,gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
