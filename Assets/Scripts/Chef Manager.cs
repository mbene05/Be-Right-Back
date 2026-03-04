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

    public AudioClip sadGuyVoice;


    void OnMouseDown()
    {
      

        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;

        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {

            if (talked == false)
            {
                talked = true;
                dialogueManager.StartDialogue(myInkJSON, sadGuyVoice);
            }

            else
            {
                if (logsCollected < 2)
                {
                    dialogueManager.StartDialogue(myInkJSON2, sadGuyVoice);
                }
                
                if (logsCollected == 2 && Giventhing == false)
                {
                    dialogueManager.StartDialogue(myInkJSON3, sadGuyVoice);
                    Giventhing = true;
                }

                else
                {
                    dialogueManager.StartDialogue(myInkJSON4, sadGuyVoice);
                }

            }
            
        }
        
    }

}