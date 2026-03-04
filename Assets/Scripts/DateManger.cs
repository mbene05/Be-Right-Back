using UnityEngine;

public class DateManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public TextAsset myInkJSON;
    public bool saidOp = false;
    public TextAsset myInkJSON2; // Assign the specific JSON for this date in Inspector

    public AudioClip interactSound;   // robot sound
    private AudioSource audioSource;
    public AudioClip charlieVoice;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

        audioSource.pitch = Random.Range(0.9f, 1.1f);


        if (interactSound != null){
            audioSource.PlayOneShot(interactSound);
        }

        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {
            dialogueManager.StartDialogue(myInkJSON, charlieVoice);
        }
        
    }
}

