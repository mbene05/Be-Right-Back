using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkJSON;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.03f;
    public GameObject dialoguePanel;
    private bool dialogueStarted = false;

    private Story story;
    private Coroutine typingCoroutine;
    private bool isTyping;

    public void Start()
    {
        story = new Story(inkJSON.text);
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // Finish line instantly
                StopCoroutine(typingCoroutine);
                dialogueText.text = story.currentText;
                isTyping = false;
            }
            else
            {
                DisplayNextLine();
            }
        }
    }

    void DisplayNextLine()
    {
        if (story.canContinue)
        {
            string line = story.Continue().Trim();
            typingCoroutine = StartCoroutine(TypeLine(line));
        }
        else
        {
            dialogueText.text = "END OF DIALOGUE";
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void StartDialogue()
    {
        if (dialogueStarted) return;

        dialogueStarted = true;
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }
}