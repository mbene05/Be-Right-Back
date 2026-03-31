using UnityEngine;

public class TilePuzzleTrigger : MonoBehaviour
{
    public bool isOpen = false;
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public bool done = false;

    public GameObject tilePuzzleRoom;
    public GameObject tilereturnRoom;
    public GameObject Arrow;

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (DialogueManager.choicesActive) return;
        if (RoomSwitcher.IsTransitioning) return;
        if (isOpen == false && done == false)
        {
            Arrow.SetActive(false);
            isOpen = true;
            mainCamera.transform.position = new Vector3(tilePuzzleRoom.transform.position.x, tilePuzzleRoom.transform.position.y, cameraZPosition);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true)
        {
            Arrow.SetActive(true);
            isOpen = false;
            mainCamera.transform.position = new Vector3(tilereturnRoom.transform.position.x, tilereturnRoom.transform.position.y, cameraZPosition);
        }
    }
}
