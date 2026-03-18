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
    public GameObject Wrench;
    public GameObject SadGuy;
    public Sprite drunkguy_no_wrench;
    public GameObject Needle;
    
    public Bar bar;

    public string endSceneName = "WinScreen"; 

    public static bool choicesActive = false;
    public static bool dialogueActive = false;
    public static bool hasChanged = false;
    public static bool IsOpen = false;

    private Story story;
    private Coroutine typingCoroutine;
    private bool isTyping;

    public GameObject[] drinks;
    public GameObject Keycard;

    public GameObject CosLog;

    private SpriteRenderer charlieRenderer;
    public Sprite charlieFace;
    public Sprite charlieFaceGood;
    public Sprite charlieFaceNeutral;
    public Sprite charlieFaceBad;
    public Sprite charlieFaceColon3;
    public Sprite charlieFaceIGotThis;
    public Sprite charlieFaceGood2;
    public Sprite charlieConfused;
    public Sprite CharlieSlightlyHappier;
    public Sprite CharlieLoading;

    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip neutralSound;

    private AudioSource audioSource;
    private AudioSource voiceSource;

    public void Start()
    {
        
        dialoguePanel.SetActive(false);
        choicesContainer.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        voiceSource = GetComponent<AudioSource>();
        voiceSource.loop = true;

        charlieRenderer = GameObject.Find("charlie color neutral_0").GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (!dialogueStarted) return;

        if (!choicesContainer.gameObject.activeSelf && Input.GetMouseButtonDown(0) && !MapManager.IsOpen && !RoomSwitcher.IsTransitioning)
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = story.currentText; // Show the full line immediately
                isTyping = false;
            }
            else if (!isTyping)
                DisplayNextLine();
        }
    }

    IEnumerator PlayVoiceForDuration(int charCount)
{

    float timePerChar = 0.0375f;
    float duration = charCount * timePerChar;

    voiceSource.loop = true;
    voiceSource.Play();

    yield return new WaitForSeconds(duration);

    voiceSource.Stop();
}

    void DisplayNextLine()
    {
        choicesActive = false;
        dialogueText.gameObject.SetActive(true);

        if (isTyping && typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            isTyping = false;
        }

        //If we can continue in the story
        while (story.canContinue)
        {
            string line = story.Continue();

            // Handle tags as soon as we advance the story
            HandleTags(story.currentTags);

            // If it's empty, skip it and keep going
            if (string.IsNullOrWhiteSpace(line))
                continue;

            line = line.Trim();

            typingCoroutine = StartCoroutine(TypeLine(line));
            StartCoroutine(PlayVoiceForDuration(line.Length));
            return; // important: stop here so we wait for input for the next line
        }

        //If there are choices
        if (story.currentChoices.Count > 0)
        {
            choicesActive = true;
            dialoguePanel.SetActive(false);
            DisplayChoices();

            
        }
        else
        {
            EndDialogue();
            if (hasChanged == true)
            {
                charlieRenderer.sprite = CharlieLoading;
                Debug.Log("Changed to loading face");
                dialogueActive = true;
            }

            hasChanged = true;

            if (dialogueActive == false) {
                StartCoroutine(DelayedFace());
            }

            dialogueActive = false;
        }
    }
    IEnumerator DelayedFace()
    {
        yield return new WaitForSeconds(25); //important for delay very very important do not forget
        charlieRenderer.sprite = charlieFace;
        Debug.Log("Delayed face back to normal");

    }
    public void Choices(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        DisplayNextLine();
    }

    void HandleTags(List<string> tags)
{
    foreach (string tag in tags)
    {
        switch (tag)
        {
            case "good":
                PlayResponseSound(goodSound);
                charlieRenderer.sprite = charlieFaceGood; 
                break;

            case "neutral":
                PlayResponseSound(neutralSound);
                charlieRenderer.sprite = charlieFaceNeutral;
                break;

            case "bad":
                PlayResponseSound(badSound);
                charlieRenderer.sprite = charlieFaceBad;
                break;

            case "colon3":
                PlayResponseSound(neutralSound);
                charlieRenderer.sprite = charlieFaceColon3;
                break;

            case "igotthis":
                PlayResponseSound(neutralSound);
                charlieRenderer.sprite = charlieFaceIGotThis;
                break;
            case "good2":
                PlayResponseSound(goodSound);
                charlieRenderer.sprite = charlieFaceGood2;
                break;
            case "confused":
                PlayResponseSound(badSound);
                charlieRenderer.sprite = charlieConfused;
                break;
            case "slightlyhappier":
                PlayResponseSound(neutralSound);
                charlieRenderer.sprite = CharlieSlightlyHappier;
                break;
            case "normal":
                charlieRenderer.sprite = charlieFace;
                break;
            case "loading":
                charlieRenderer.sprite = CharlieLoading;
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
        choicesActive = true;
        dialogueText.text = "";



        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

        isTyping = false;
    }

    public void StartDialogue(TextAsset newInkJSON, AudioClip voiceClip)
    {
        Start();
        if (dialogueStarted) return;

        if (dialogueActive == false) {

            charlieRenderer.sprite = charlieFace;

        }

        voiceSource.clip = voiceClip;

        dialogueStarted = true;
        IsOpen = true;
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
                Wrench.SetActive(true);
                SpriteRenderer sr = SadGuy.GetComponent<SpriteRenderer>();
                sr.sprite = drunkguy_no_wrench;
            });
             story.BindExternalFunction("giveLog", (int givenLog) => {
                Keycard.SetActive(true);
            });
             story.BindExternalFunction("giveLog2", (int givenLog2) => {
                CosLog.SetActive(true);
            });

             story.BindExternalFunction("getNeedle", (int needGot) => {
                Needle.SetActive(true);
            });

        DisplayNextLine();

    }

    public void LoadingDialogue(TextAsset newInkJSON, AudioClip voiceClip)
    {

        Start();
        if (dialogueStarted) return;

        voiceSource.clip = voiceClip;

        dialogueStarted = true;
        IsOpen = true;
        dialoguePanel.SetActive(true);

        // Assign the new Ink JSON
        inkJSON = newInkJSON;
        story = new Story(inkJSON.text);

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
        choicesActive = false;

        story.ChooseChoiceIndex(choiceIndex);
        choicesContainer.gameObject.SetActive(false);
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueStarted = false;
        IsOpen = false;
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

