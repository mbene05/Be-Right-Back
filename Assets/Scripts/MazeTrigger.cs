using UnityEngine;

public class MazeTrigger : MonoBehaviour
{
    public GameObject MazeGame;
    public GameObject backButton;
    public DialogueManager dialogueManager;
    void OnMouseDown()
    {
        if (MazeGame.GetComponent<MazeMiniGame>().done2 == false)
        {
            if (dialogueManager.dialogueStarted) return;
             if (MapManager.IsOpen) return;
             if (PinCodeMiniGame.IsOpen) return;
              if (DialogueManager.choicesActive) return;
             if (RoomSwitcher.IsTransitioning) return;
            MazeMiniGame.Instance.Open();
            backButton.SetActive(true);
        }
    }
}
