using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleController : MonoBehaviour
{
    // Period between letters
    public float TypingPeriod = 0.5F;
    // Period between lines
    public float NewlineWait = 1F;
    // How much to wait until destroying
    public float EndWait = 2F;

    private Text textComponent;

    public void StartAnimation(string text)
    {
        textComponent = transform.GetChild(0).GetComponent<Text>();
        StartCoroutine(AnimateText(text));
    }

    IEnumerator AnimateText(string text)
    {
        var currentText = "";
        foreach(char i in text)
        {
            if(i == '\n')
            {
                yield return new WaitForSeconds(NewlineWait);
                currentText = "";
                continue;
            }

            currentText += i;
            textComponent.text = currentText;

            yield return new WaitForSeconds(TypingPeriod);
        }

        yield return new WaitForSeconds(EndWait);
        Destroy(gameObject);
    }
}
