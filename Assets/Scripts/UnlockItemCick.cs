using UnityEngine;

public class UnlockItemCick : MonoBehaviour 
{
    public DialogueManager dialogueManager;


    public TextAsset myInkJSON; 
    public bool opened = false;

    public AudioClip importantItem;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
      
        if (dialogueManager.dialogueStarted) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (DialogueManager.choicesActive) return;
        if (RoomSwitcher.IsTransitioning) return;
        opened = true;
       
        audioSource.PlayOneShot(importantItem);

        dialogueManager.StartDialogue(myInkJSON, null);
       
    }
              


}