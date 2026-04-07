using UnityEngine;
using System.Collections;

public class DateManager : MonoBehaviour, IUsableWithItem
{
    public DialogueManager dialogueManager;
    public TextAsset myInkJSON;
    public TextAsset myInkJSON2;
    public TextAsset myInkJSON3;
    public TextAsset myInkJSONFinal;
    public TextAsset drinkDropInkJSON;
    public TextAsset wrenchDropInkJSON;
    public static bool saidOp;
    public GameObject bar;
    public static void ResetStatics()
    {
        saidOp = false;
    }
    public GameObject phone;

    public bool Distracted = false;

    public AudioClip interactSound;
    public GameObject TableMenu;
    public AudioClip charlieVoice;

    private AudioSource audioSource;

    private SpriteRenderer charlieRenderer;
    public Sprite charlieNormal;
    public Sprite DistractedSprite;
  

    private float nextAvailableTime;
    private BoxCollider2D boxCollider;
    public float cooldownDuration;
    public bool saidOpeningFr = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        charlieRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
        if (Distracted)
        {
            charlieRenderer.sprite = DistractedSprite;
        }
        if (saidOp == false && saidOpeningFr == false)
        {
            dialogueManager.StartDialogue(myInkJSON2, charlieVoice);
            saidOp = true;
            saidOpeningFr = true;
        }
    
    }

    void OnMouseDown()
    {
        if (TableMenu.GetComponent<DrinkMenuTable>().HasClicked == true) return;
        if (phone.GetComponent<PhoneScript>().HasClicked == true) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (DialogueManager.choicesActive) return;
        if (RoomSwitcher.IsTransitioning) return;

        if (Distracted)
        {
            dialogueManager.LoadingDialogue(myInkJSONFinal, charlieVoice);
        }

        else
        {
            if (Time.time < nextAvailableTime)
            {

                Debug.Log("Ability is on cooldown! Time remaining: " + (nextAvailableTime - Time.time).ToString("F2") + "s");

                dialogueManager.LoadingDialogue(myInkJSON3, charlieVoice);
                DialogueManager.hasChanged = false;
                DialogueManager.dialogueActive = true;

                return;
            }

            audioSource.pitch = Random.Range(0.9f, 1.1f);

            if (interactSound != null)
            {
                audioSource.PlayOneShot(interactSound);
            }

            UseAbility();

            if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
            {
                DialogueManager.dialogueActive = true;
                dialogueManager.StartDialogue(myInkJSON, charlieVoice);
                DialogueManager.dialogueActive = false;

            }
        }
    }

    public void UseAbility()
    {
        
        Bar bars = bar.GetComponent<Bar>();
        nextAvailableTime = Time.time + (cooldownDuration * bars.percent);

        DialogueManager.dialogueActive = false;
        StartCoroutine(CooldownRoutine());
        StartCoroutine(ReturnToNormalFace());
    }

    IEnumerator CooldownRoutine()
    {
         Bar bars = bar.GetComponent<Bar>();
        yield return new WaitForSeconds(cooldownDuration * bars.percent);
        dialogueManager.StartCoroutine(dialogueManager.DelayedFace());
    }

    IEnumerator ReturnToNormalFace()
    {
        Bar bars = bar.GetComponent<Bar>();
        yield return new WaitForSeconds(cooldownDuration * bars.percent);

        if (charlieRenderer != null && charlieNormal != null && Distracted == false)
        {
            charlieRenderer.sprite = charlieNormal;
        }
    }

    public bool UseWithItem(Item item, Vector3 hitPoint)
    {
        if (item == null) return false;
        if (item.itemName == "Needle" || item.itemName == "ComputerChip") return false;

        bool isDrink = item.groupID == "drinks";
        bool isWrench = item.itemName == "Wrench";
        if (!isDrink && !isWrench) return false;

        if (DialogueManager.choicesActive) return false;
        if (RoomSwitcher.IsTransitioning) return false;

        UseAbility();

        TextAsset dialogueToPlay = isDrink ? drinkDropInkJSON : wrenchDropInkJSON;
        if (dialogueToPlay != null && !dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {
            dialogueManager.StartDialogue(dialogueToPlay, charlieVoice);
        }

        return false;
    }

}