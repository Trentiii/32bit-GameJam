using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromptFader : MonoBehaviour
{

    TMP_Text self;

    private void Start()
    {
        self = GetComponent<TMP_Text>();
    }

    public void startPrompt()
    {
        StartCoroutine(fader());
    }

    private IEnumerator fader()
    {
        while (self.color.a < 1)
        {
            self.color += new Color(self.color.r, self.color.g, self.color.b, 0.025f);

            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
        }

        self.color = new Color(self.color.r, self.color.g, self.color.b, 1);
        yield return new WaitForSeconds(5);

        while (self.color.a > 0)
        {
            self.color -= new Color(self.color.r, self.color.g, self.color.b, 0.025f);

            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
        }

        self.color = new Color(self.color.r, self.color.g, self.color.b, 0);
    }
}
