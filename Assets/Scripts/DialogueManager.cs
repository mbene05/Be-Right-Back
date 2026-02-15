using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class DialogueManager : MonoBehaviour
{
    public TextAsset inkJSON;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.03f;
    public GameObject dialoguePanel;
    public bool dialogueStarted = false;
    public Transform choicesContainer;
    public GameObject choiceButtonPrefab;
    public Bar bar;  

    public string endSceneName = "WinScreen"; 

    private Story story;
    private Coroutine typingCoroutine;
    private bool isTyping;

    public GameObject[] drinks;

    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip neutralSound;
    public AudioClip bartenderVoice;

    private AudioSource audioSource;
    private AudioSource voiceSource;

    public void Start()
    {
        
        dialoguePanel.SetActive(false);
        choicesContainer.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        voiceSource = GetComponent<AudioSource>();
        voiceSource.clip = bartenderVoice; //change when i add more voices
        voiceSource.loop = true;
        
    }

    void Update()
    {
        if (!choicesContainer.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
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

    IEnumerator PlayVoiceForDuration(int charCount)
{

    float timePerChar = 0.038f;
    float duration = charCount * timePerChar;

    voiceSource.loop = true;
    voiceSource.Play();

    yield return new WaitForSeconds(duration);

    voiceSource.Stop();
}

    void DisplayNextLine()
    {
        dialogueText.gameObject.SetActive(true);

        //If we can continue in the story
        if (story.canContinue)
        {

            string line = story.Continue().Trim();
            typingCoroutine = StartCoroutine(TypeLine(line));
            StartCoroutine(PlayVoiceForDuration(line.Length));

            HandleTags(story.currentTags);


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

    void HandleTags(List<string> tags)
{
    foreach (string tag in tags)
    {
        switch (tag)
        {
            case "good":
                PlayResponseSound(goodSound);
                break;

            case "neutral":
                PlayResponseSound(neutralSound);
                break;

            case "bad":
                PlayResponseSound(badSound);
                break;
        }
    }
}

void PlayResponseSound(AudioClip clip)
{
    if (clip == null) return;

    audioSource.PlayOneShot(clip);
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

    public void StartDialogue(TextAsset newInkJSON)
    {
        Start();
        if (dialogueStarted) return; 

        dialogueStarted = true;
        dialoguePanel.SetActive(true);
         // Assign the new Ink JSON
         inkJSON = newInkJSON;
          story = new Story(inkJSON.text); 
          // Bind functions so Ink can call them
            story.BindExternalFunction("AddToBar", (float amount) => {
                bar.AddTime(amount);
            });

            story.BindExternalFunction("SubToBar", (float amount) => {
                bar.ReduceTime(amount);
            });
            
              story.BindExternalFunction("DrinkRecieved", (int drinkNum) => {
                ActivateDrink(drinkNum);
            });

              story.BindExternalFunction("EndedGame", (int didyouend) => {
                LoadEndScene();
            });

        DisplayNextLine();
    }

    void DisplayChoices()
    {
        choicesContainer.gameObject.SetActive(true);

        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            Choice choice = story.currentChoices[i];

            GameObject buttonGO = Instantiate(choiceButtonPrefab, choicesContainer);
            buttonGO.SetActive(true); 
            buttonGO.name = "ChoiceButtonInstance";

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
            if (child.name == "ChoiceButtonInstance")
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
        choicesContainer.gameObject.SetActive(false); 
    }

    void ActivateDrink(int drinkNum)
    {
        for (int i = 0; i < drinks.Length; i++)
        {
            if (drinks[i] != null)
                drinks[i].SetActive(i == drinkNum); // Activate only the selected drink
        }
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene(endSceneName);
    }
}

