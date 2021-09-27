using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class queenDeathEnding : MonoBehaviour
{

    public static bool started = false;
    bool done = false;

    public PlayerDeath pd;
    public GameObject endingScreen;
    public Image whiteFade;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (started && !done)
        {
            StartCoroutine(ending());
            endingScreen.SetActive(true);
            pd.enabled = false;
            Time.timeScale = 0.5f;
            done = true;
        }
    }

    private IEnumerator ending()
    {
        while (whiteFade.color.a < 1)
        {
            if (Time.timeScale > 0)
                Time.timeScale -= Time.deltaTime * 7;

            if (whiteFade.color.a < 1)
            {
                whiteFade.color += new Color(whiteFade.color.r, whiteFade.color.g, whiteFade.color.b, 0.025f);
            }


            yield return new WaitForSecondsRealtime(0.12f);
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
