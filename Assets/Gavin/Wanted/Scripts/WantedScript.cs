using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WantedScript : MonoBehaviour
{
    public Sprite hiddenImage;
    public Sprite seenImage;
    public Image wantedUI;

    public float hiddenTime;

    bool hidden = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        wantedUI.sprite = hidden ? hiddenImage : seenImage;
    }

    public void OnTriggerEnter(Collider other)
    {
        print(1);
        Seen();
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        print(4);
    }

    public void Seen()
    {
        hidden = false;
        StartCoroutine("TurnOnHidden");
        print(2);
    }

    IEnumerator TurnOnHidden()
    {
        yield return new WaitForSeconds(hiddenTime);
        hidden = true;
        print(3);
        
    }
}
