using UnityEngine;
using UnityEngine.SceneManagement;

public class SadGuyManager : MonoBehaviour, IUsableWithItem
{
    public DialogueManager dialogueManager;


    public TextAsset myInkJSON; 
    public TextAsset myInkJSON2; 
    public TextAsset myInkJSON3;
    public TextAsset myInkJSON5;
    public TextAsset myInkJSON6;
    public TextAsset wrongDrink;
    public TextAsset angryGuy;

    public bool GivenDrink = false;


    public GameObject Hotbar;
    public GameObject Bartender;
    public GameObject highlighted;

    public bool rightDrink = false;
    public bool pickUpDrink = false;
    public bool hasReceivedDrink = false;
    public bool hasTalked = false;


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
        if (MazeMiniGame.IsOpen) return;
        if (DialogueManager.choicesActive) return;
        if (RoomSwitcher.IsTransitioning) return;
        DialogueManager.hasChanged = false;
        if (GivenDrink == true)
        {
            dialogueManager.StartDialogue(myInkJSON5, sadGuyVoice);
        }

        else
        {
        if (rightDrink == true && GivenDrink) {
            if (hasTalked == true)
            {
                dialogueManager.StartDialogue(myInkJSON6, sadGuyVoice);
            }

            else
            {
                dialogueManager.StartDialogue(myInkJSON3, sadGuyVoice);
            }
          
        }
        if (hasTalked == true)
        {
            dialogueManager.StartDialogue(myInkJSON, sadGuyVoice);
        }
        else if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {
            dialogueManager.StartDialogue(myInkJSON3, sadGuyVoice);
            hasTalked = true;
        }
        }

    }


    public bool UseWithItem(Item item, Vector3 hitPoint)
    {
        if (dialogueManager.dialogueStarted || dialogueManager.choicesContainer.gameObject.activeSelf)
            return false;



        highlighted.SetActive(false);


        BartenderManager selectedBartender = Bartender.GetComponent<BartenderManager>();
        selectedBartender.pickUpDrink = false;

        if (!rightDrink)
        {
            dialogueManager.StartDialogue(wrongDrink, sadGuyVoice);
            hasReceivedDrink = false;
            myInkJSON = angryGuy;
        }

        else if (rightDrink)
        {
            dialogueManager.StartDialogue(myInkJSON2, sadGuyVoice);
            GivenDrink = true;

        }




        return true;

    }
}