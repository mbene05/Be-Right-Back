using UnityEngine;

public class FrontEntranceDia : MonoBehaviour 
{
    public DialogueManager dialogueManager;


    public TextAsset myInkJSON; 
    
    public AudioSource audioSource;
    public AudioClip DateVoice;

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
       

        dialogueManager.StartDialogue(myInkJSON, DateVoice);
       
    }
              


}