using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LockedArrowTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public TextAsset myInkJSON;


    void OnMouseDown()
    {
        if (dialogueManager.dialogueStarted) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;

        dialogueManager.StartDialogue(myInkJSON, null);
    }

}
