using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    bool isOpen = false;
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public GameObject pipePuzzleRoom;
    public GameObject returnRoom;
    void OnMouseDown()
    {
        if (isOpen == false)
        { 
        isOpen = true;
        mainCamera.transform.position = new Vector3( pipePuzzleRoom.transform.position.x,  pipePuzzleRoom.transform.position.y, cameraZPosition);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true)
        {
            isOpen = false;
             mainCamera.transform.position = new Vector3(returnRoom.transform.position.x,  returnRoom.transform.position.y, cameraZPosition);
        }
    }
}
