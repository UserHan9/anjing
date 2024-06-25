using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Writing : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float wordSpeed;
    public float lineDelay;  // Delay before moving to the next line

    private int lineIndex;

    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue()
    {
        lineIndex = 0;
        StartCoroutine(DisplayLine());
    }

    IEnumerator DisplayLine()
    {
        string[] words = dialogueLines[lineIndex].Split(' ');
        if (words.Length > 0)
        {
            foreach (string word in words)
            {
                dialogueText.text += word + " ";
                Debug.Log("kata 1 per 1");
                yield return new WaitForSeconds(wordSpeed);
            }

            yield return new WaitForSeconds(lineDelay);  // Wait before proceeding to the next line
            NextLine();
        }
        else
        {
            Debug.Log("tidak");
        }
    }

    void NextLine()
    {
        if (lineIndex < dialogueLines.Length - 1)
        {
            lineIndex++;
            dialogueText.text = string.Empty;
            StartCoroutine(DisplayLine());
        }
        else
        {
            dialogueText.text = string.Empty;
            // End of dialogue, you can add more
        }
    }
}
