using UnityEngine;

public class SadGuyManager : MonoBehaviour, IUsableWithItem
{
    public DialogueManager dialogueManager;


    public TextAsset myInkJSON; 
    public TextAsset myInkJSON2; 

    public TextAsset myInkJSON3; 

    public GameObject Hotbar;
    public GameObject Bartender;
    public GameObject highlighted;

    public bool rightDrink = false;
    public bool pickUpDrink = false;

    public AudioClip sadGuyVoice;

    void OnMouseOver()
    {
        if (dialogueManager.dialogueStarted || dialogueManager.choicesContainer.gameObject.activeSelf)
        {
            highlighted.SetActive(false);
        }
        else
        {
            highlighted.SetActive(true);
        }

    }

    void OnMouseExit()
    {
        highlighted.SetActive(false);
    }


    void OnMouseDown()
    {
        highlighted.SetActive(false);

        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;

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


    public bool UseWithItem(Item item, Vector3 hitPoint)
    {
        if (dialogueManager.dialogueStarted || dialogueManager.choicesContainer.gameObject.activeSelf)
            return false;

        if (!pickUpDrink)
            return false;

        highlighted.SetActive(false);

        BartenderManager selectedBartender = Bartender.GetComponent<BartenderManager>();
        selectedBartender.pickUpDrink = false;

        if (rightDrink)
        {
            dialogueManager.StartDialogue(myInkJSON2, sadGuyVoice);
        }
        else
        {
            dialogueManager.StartDialogue(myInkJSON, sadGuyVoice);
        }

        return true;
    }
}