using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenTutorial()
    {
        gameObject.SetActive(true);
    }
    public void CloseTutorial()
    {
        gameObject.SetActive(false);
    }
}
