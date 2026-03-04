using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public GameObject pipePuzzleRoom;
    public string requiredItemName = "Wrench";

    private HotbarManager hotbar;
    private bool isOpen = false;

    void Start()
    {
        hotbar = FindObjectOfType<HotbarManager>();
    }

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (isOpen) return;

        if (hotbar != null && !hotbar.HasItem(requiredItemName))
        {
            Debug.Log("You need a " + requiredItemName + " to access this.");
            return;
        }

        mainCamera.transform.position = new Vector3(pipePuzzleRoom.transform.position.x, pipePuzzleRoom.transform.position.y, cameraZPosition);
    }
}
