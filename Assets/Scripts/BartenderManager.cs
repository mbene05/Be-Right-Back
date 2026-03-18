using UnityEditor;
using UnityEngine;

public class BartenderManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public GameObject drinkmenuPanel;
    public TextAsset myInkJSON; 
    public TextAsset myInkJSON2; 

    public TextAsset myInkJSON3;

    public AudioClip bartenderVoice;

    public GameObject highlighted;

    public bool pickUpDrink = false;

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
        if (dialogueManager.dialogueStarted) return;

        highlighted.SetActive(false);

        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (DialogueManager.choicesActive) return;
        if (RoomSwitcher.IsTransitioning) return;


        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {

            DrinkMenuTable menuScript = drinkmenuPanel.GetComponent<DrinkMenuTable>();
            

            if (pickUpDrink == true)
            {
                 dialogueManager.StartDialogue(myInkJSON3,bartenderVoice);
            }

            else
            {
                if (menuScript != null && menuScript.HasClicked)
                {
                    dialogueManager.StartDialogue(myInkJSON2, bartenderVoice);
                }

                else
                {
                    dialogueManager.StartDialogue(myInkJSON, bartenderVoice);
                }  
            }
            
        }
        
    }
}