using UnityEngine;

public class DateManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public TextAsset myInkJSON; // Assign the specific JSON for this date in Inspector

    public AudioClip interactSound;   // robot sound
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            Debug.LogError("Robot has no AudioSource!");
    }


    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;

        audioSource.pitch = Random.Range(0.9f, 1.1f);


        if (interactSound != null){
            audioSource.PlayOneShot(interactSound);
        }

        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {
            dialogueManager.StartDialogue(myInkJSON);
        }
        
    }
}

