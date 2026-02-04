using UnityEngine;

public class DateManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void OnMouseDown()
    {
        
        if (!dialogueManager.dialogueStarted && !dialogueManager.choicesContainer.gameObject.activeSelf)
        {
            dialogueManager.StartDialogue();
        }
        
    }
}