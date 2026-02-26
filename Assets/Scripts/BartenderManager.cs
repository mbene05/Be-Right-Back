using UnityEngine;

public class BartenderManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public GameObject drinkmenuPanel;
    public TextAsset myInkJSON; 
    public TextAsset myInkJSON2; 

    public TextAsset myInkJSON3; 

    public bool pickUpDrink = false;

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;

        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {

            DrinkMenu menuScript = drinkmenuPanel.GetComponent<DrinkMenu>();
            

            if (pickUpDrink == true)
            {
                 dialogueManager.StartDialogue(myInkJSON3);
            }

            else
            {
                if (menuScript != null && menuScript.HasClicked)
                {
                    dialogueManager.StartDialogue(myInkJSON2);
                }

                else
                {
                    dialogueManager.StartDialogue(myInkJSON);
                }  
            }
            
        }
        
    }
}