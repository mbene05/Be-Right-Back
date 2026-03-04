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
                if (logsCollected == 0)
                {
                    dialogueManager.StartDialogue(myInkJSON2, sadGuyVoice);
                }
                
                else if (logsCollected == 1)
                {
                    dialogueManager.StartDialogue(myInkJSON3, sadGuyVoice);
                }

                else 
                {
                    dialogueManager.StartDialogue(myInkJSON4, sadGuyVoice);
                }

            }
            
        }
        
    }

}