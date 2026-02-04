using UnityEngine;

public class DateManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public TextAsset myInkJSON; // Assign the specific JSON for this date in Inspector

    void OnMouseDown()
    {
       

        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {
            dialogueManager.StartDialogue(myInkJSON);
        }
        
    }
}

