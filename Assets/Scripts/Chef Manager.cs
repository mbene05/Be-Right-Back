using UnityEngine;

public class ChefManager : MonoBehaviour 
{
    public DialogueManager dialogueManager;


    public TextAsset myInkJSON; 
    public TextAsset myInkJSON2; 

    public TextAsset myInkJSON3; 

    public TextAsset myInkJSON4;

    public GameObject Hotbar;
    public GameObject Bartender;

    public bool Giventhing = false;


    public int logsCollected = 0;
    public bool talked = false;
    public AudioSource audioSource;
    public AudioClip ChefVoice;

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

        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {

            if (talked == false)
            {
                
                dialogueManager.StartDialogue(myInkJSON, ChefVoice);
                talked = true;
            }

            else
            {
                if (logsCollected == 2)
                {
                    dialogueManager.StartDialogue(myInkJSON4, ChefVoice);
                }
                
                if (logsCollected == 2 && Giventhing == false)
                {
                    dialogueManager.StartDialogue(myInkJSON3, ChefVoice);
                    Giventhing = true;
                }

                else
                {
                    dialogueManager.StartDialogue(myInkJSON2, ChefVoice);
                }

            }
            
        }
        
    }

}