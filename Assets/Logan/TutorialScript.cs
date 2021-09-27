using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    public PromptFader prompt;
    public static bool first = true;


    public void OpenTutorial()
    {
        gameObject.SetActive(true);
    }
    public void CloseTutorial()
    {
        if (first)
        {
            first = false;
            prompt.startPrompt();
        }
        gameObject.SetActive(false);
    }
}
