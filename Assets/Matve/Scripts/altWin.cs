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
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Instantiate(modelDead, gameObject.transform.position, Quaternion.identity);
            winScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
