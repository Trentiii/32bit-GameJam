using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(HexaSpinGrow))]
public class PauseMenu : MonoBehaviour
{
    [HideInInspector]
    public static bool paused = false;

    HexaSpinGrow hsg;
    [SerializeField] TutorialScript tutorialScript;

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
        if (Input.GetKeyDown(KeyCode.Escape) && !tutorialScript.gameObject.activeSelf)
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

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }

    public void OpenTutorial()
    {
        tutorialScript.OpenTutorial();
        hsg.spinShrinkStart();
    }
}
