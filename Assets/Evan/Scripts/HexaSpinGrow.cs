using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaSpinGrow : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void spinGrowStart()
    {
        StartCoroutine(spinGrow());
    }

    public void spinShrinkStart()
    {
        StartCoroutine(spinShrink());
    }

    private IEnumerator spinGrow()
    {
        Time.timeScale = 0;

        while (transform.localScale.x < 1.1)
        {
            transform.eulerAngles += new Vector3(0, 0, 36);
            transform.localScale += new Vector3(1.1f / 10 , 1.1f / 10, 1);
            yield return new WaitForSecondsRealtime(0.03f);
        }

        PauseMenu.paused = true;
    }

    private IEnumerator spinShrink()
    {
        while (transform.localScale.x > 0)
        {
            transform.eulerAngles -= new Vector3(0, 0, 36);
            transform.localScale -= new Vector3(1.1f / 10, 1.1f / 10, 1);
            yield return new WaitForSecondsRealtime(0.03f);
        }

        PauseMenu.paused = false;
        Time.timeScale = 1;

    }
}
