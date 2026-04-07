using UnityEngine;

public class TilePuzzleTrigger : MonoBehaviour
{
    public bool isOpen = false;
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public bool done = false;

    public GameObject tilePuzzleRoom;
    public GameObject tilereturnRoom;
    public DialogueManager dialogueManager;
    public GameObject Arrow;
    public GameObject Arrow2;

    public AudioClip tilePuzzleOpenSound;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (dialogueManager.dialogueStarted) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (DialogueManager.choicesActive) return;
        if (RoomSwitcher.IsTransitioning) return;
        audioSource.PlayOneShot(tilePuzzleOpenSound);
        if (isOpen == false && done == false)
        {
            Arrow.SetActive(false);
            Arrow2.SetActive(false);
            isOpen = true;
            mainCamera.transform.position = new Vector3(tilePuzzleRoom.transform.position.x, tilePuzzleRoom.transform.position.y, cameraZPosition);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true)
        {
            Arrow.SetActive(true);
            Arrow2.SetActive(true);
            isOpen = false;
            mainCamera.transform.position = new Vector3(tilereturnRoom.transform.position.x, tilereturnRoom.transform.position.y, cameraZPosition);
        }
    }
}
