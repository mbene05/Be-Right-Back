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
    public Transform choicesContainer;
    public GameObject choiceButtonPrefab;

    private Story story;
    private Coroutine typingCoroutine;
    private bool isTyping;

    public void Start()
    {
        story = new Story(inkJSON.text);
        dialoguePanel.SetActive(false);
        choicesContainer.gameObject.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
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
        dialogueText.gameObject.SetActive(true);

        //If we can continue in the story
        if (story.canContinue)
        {
            string line = story.Continue().Trim();
            typingCoroutine = StartCoroutine(TypeLine(line));
        }
        //If there are choices
        else if (story.currentChoices.Count > 0)
        {
            dialoguePanel.SetActive(false);
            DisplayChoices();
        }
        else
        {
            EndDialogue();
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

    void DisplayChoices()
    {
        

        //Show the container
        choicesContainer.gameObject.SetActive(true);

        // Loop through all choices in the story
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            Choice choice = story.currentChoices[i];

            GameObject buttonGO = Instantiate(choiceButtonPrefab, choicesContainer);
            buttonGO.SetActive(true); 

            TextMeshProUGUI buttonText = buttonGO.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.text;

            int choiceIndex = i; 
            buttonGO.GetComponent<UnityEngine.UI.Button>()
                .onClick.AddListener(() => OnChoiceSelected(choiceIndex));
        }
    }

    void OnChoiceSelected(int choiceIndex)
    {
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }
        story.ChooseChoiceIndex(choiceIndex);
        choicesContainer.gameObject.SetActive(false);
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueStarted = false;
        isTyping = false;
    }
}

