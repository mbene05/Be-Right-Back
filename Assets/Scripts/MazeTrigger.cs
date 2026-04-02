using UnityEngine;

public class MazeTrigger : MonoBehaviour
{
    public GameObject MazeGame;
    public GameObject backButton;
    public DialogueManager dialogueManager;

    public AudioClip mazeOpenSound;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            AudioSource.PlayClipAtPoint(mazeOpenSound, transform.position,0.8f);
            backButton.SetActive(true);
        }
    }
}
