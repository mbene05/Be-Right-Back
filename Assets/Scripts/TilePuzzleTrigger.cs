using UnityEngine;

public class TilePuzzleTrigger : MonoBehaviour
{
    bool isOpen = false;
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public bool done = false;
    private MapManager mapManager;
 


    public GameObject tilePuzzleRoom;
    public GameObject tilereturnRoom;

    public void Start()
    {
         mapManager = FindObjectOfType<MapManager>();
    }
    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (isOpen == false && done == false)
        { 
            mapManager.toggleButton.interactable = false;
            isOpen = true;
            mainCamera.transform.position = new Vector3( tilePuzzleRoom.transform.position.x,  tilePuzzleRoom.transform.position.y, cameraZPosition);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true)
        {
            mapManager.toggleButton.interactable = true;
            isOpen = false;
             mainCamera.transform.position = new Vector3( tilereturnRoom.transform.position.x,  tilereturnRoom.transform.position.y, cameraZPosition);
        }
    }
}