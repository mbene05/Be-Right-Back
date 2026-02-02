using UnityEngine;

public class DateManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void OnMouseDown()
    {
        dialogueManager.StartDialogue();
    }
}