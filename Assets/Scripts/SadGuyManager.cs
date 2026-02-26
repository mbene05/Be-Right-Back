using UnityEngine;

public class SadGuyManager : MonoBehaviour
{
    public DialogueManager dialogueManager;


    public TextAsset myInkJSON; 
    public TextAsset myInkJSON2; 

    public TextAsset myInkJSON3; 

    public GameObject Hotbar;
    public GameObject Bartender;

    public bool rightDrink = false;
    public bool pickUpDrink = false;

    public AudioClip sadGuyVoice;


    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;

        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {

            if (pickUpDrink == false)
            {
                dialogueManager.StartDialogue(myInkJSON3, sadGuyVoice);
            }

            else
            {
                if (rightDrink == true)
                {
                    HotbarManager hotbar = Hotbar.GetComponent<HotbarManager>();
                    BartenderManager selectedBartender = Bartender.GetComponent<BartenderManager>();
                    selectedBartender.pickUpDrink = false;
                    hotbar.getridofslot1();
                    dialogueManager.StartDialogue(myInkJSON2, sadGuyVoice);
                }

                else
                {
                     HotbarManager hotbar = Hotbar.GetComponent<HotbarManager>();
                     hotbar.getridofslot1();
                      BartenderManager selectedBartender = Bartender.GetComponent<BartenderManager>();
                     selectedBartender.pickUpDrink = false;
                     dialogueManager.StartDialogue(myInkJSON, sadGuyVoice);
                }
            }
            
        }
        
    }

   
}