using UnityEngine;

public class DateManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public TextAsset myInkJSON;
    public TextAsset myInkJSON2;
    public bool saidOp = false;

    public AudioClip interactSound;
    public AudioClip charlieVoice;

    private AudioSource audioSource;

    private SpriteRenderer charlieRenderer;
    public Sprite charlieLoading;

    private float nextAvailableTime;
    private BoxCollider2D boxCollider;
    public float cooldownDuration;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        charlieRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (saidOp == false)
        {
            dialogueManager.StartDialogue(myInkJSON2, charlieVoice);
            saidOp = true;
        }
    }

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;

        if (Time.time < nextAvailableTime)
        {
            Debug.Log("Ability is on cooldown! Time remaining: " + (nextAvailableTime - Time.time).ToString("F2") + "s");
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
            dialogueManager.StartDialogue(myInkJSON, charlieVoice);
        }
    }

    public void UseAbility()
    {
        nextAvailableTime = Time.time + cooldownDuration;

        if (charlieRenderer != null && charlieLoading != null)
        {
            charlieRenderer.sprite = charlieLoading;
        }
    }
}