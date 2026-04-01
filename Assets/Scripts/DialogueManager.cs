using Ink.Runtime;
using Ink.UnityIntegration;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Globals Ink File")]
    [SerializeField] private InkFile globalInkFile;
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

    public GameObject coatroomArrow;
    public GameObject backkitchenArrow;
    
    public Bar bar;

    public string endSceneName = "WinScreen"; 

    public static bool choicesActive = false;
    public static bool dialogueActive = false;
    public static bool hasChanged = false;
    public static bool IsOpen = false;

    private Story story;
    private Coroutine typingCoroutine;
    private bool isTyping;
    private bool needleGiven = false;

    public GameObject[] drinks;
    public GameObject Keycard;

    public GameObject CosLog;
    public GameObject speechBubble;
    public GameObject speechBubble2;

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
    public AudioClip charlieReadyBeep;

    private AudioSource audioSource;
    private AudioSource voiceSource;

    private DialogueVariables dialogueVariables;

    private void Awake()
    {
        dialogueVariables = new DialogueVariables(globalInkFile.filePath);
    }

    public void Start()
    {
        speechBubble.gameObject.SetActive(false);
        choicesActive = false;
        dialogueActive = false;
        hasChanged = false;
        IsOpen = false;

        dialoguePanel.SetActive(false);
        choicesContainer.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        voiceSource = GetComponent<AudioSource>();
        voiceSource.loop = true;

        charlieRenderer = GameObject.Find("charlie color neutral_0").GetComponent<SpriteRenderer>();
        charlieRenderer.sprite = charlieFace;


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
             SceneManager.LoadScene("MainTitle");
        }


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
            }

            hasChanged = true;

            if (dialogueActive == false) {
                StartCoroutine(DelayedFace());
            }


        }
    }
    IEnumerator DelayedFace()
    {
        yield return new WaitForSeconds(20); //important for delay very very important do not forget
        charlieRenderer.sprite = charlieFace;
/*        if (RoomSwitcher.currentRoom == 1)
        {
            speechBubble2.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            speechBubble2.gameObject.SetActive(false);
        }*/
        speechBubble.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        speechBubble.gameObject.SetActive(false);
        //audioSource.PlayOneShot(charlieReadyBeep);
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
        dialogueVariables.StartListening(story);

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
                coatroomArrow.SetActive(false);
                backkitchenArrow.SetActive(false);
            });
             story.BindExternalFunction("giveLog2", (int givenLog2) => {
                CosLog.SetActive(true);
            });

             story.BindExternalFunction("getNeedle", (int needGot) => {
                if (!needleGiven)
                {
                    needleGiven = true;
                    Needle.SetActive(true);
                }
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
        dialogueVariables.StopListening(story);
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

