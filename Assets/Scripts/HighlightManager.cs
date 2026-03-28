using UnityEditor;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public GameObject highlighted;

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
    }
}
