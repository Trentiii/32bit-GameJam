using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public void OpenTutorial()
    {
        gameObject.SetActive(true);
    }
    public void CloseTutorial()
    {
        gameObject.SetActive(false);
    }
}
