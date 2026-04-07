using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public bool playSfx = false;

    public bool GivenDrink = false;
    private bool waitingToShowOverlay = false;


    public GameObject Hotbar;
    public GameObject Bartender;
    public GameObject highlighted;

    public bool rightDrink = false;
    public bool pickUpDrink = false;
    public bool hasReceivedDrink = false;
    public AudioSource audioSource;
    public bool hasTalked = false;

    public AudioClip SadGuyDrunk;
    public AudioClip sadGuyVoice;
    public GameObject drinkAcceptedOverlay;

    void OnMouseOver()
    {
        if (dialogueManager.dialogueStarted || dialogueManager.choicesContainer.gameObject.activeSelf || RoomSwitcher.IsTransitioning)
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


    void Update()
    {
        if (waitingToShowOverlay && !dialogueManager.dialogueStarted)
        {
            waitingToShowOverlay = false;
            StartCoroutine(ShowDrinkAccepted());
        }
    }

    IEnumerator ShowDrinkAccepted()
    {
        if (drinkAcceptedOverlay != null)
        {
            if (playSfx == false)
            {
                audioSource.PlayOneShot(SadGuyDrunk);
                playSfx = true;
            }
            drinkAcceptedOverlay.SetActive(true);
            yield return new WaitForSeconds(2f);
            drinkAcceptedOverlay.SetActive(false);
        }
    }

    public bool UseWithItem(Item item, Vector3 hitPoint)
    {
        if (item.groupID != "drinks") return false;

        if (dialogueManager.dialogueStarted || dialogueManager.choicesContainer.gameObject.activeSelf)
            return false;
        
        if (GivenDrink)
        {
            return false;
        }

        highlighted.SetActive(false);

        rightDrink = item.itemName == "ZipBomb";

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
            waitingToShowOverlay = true;
        }




        return true;

    }
}