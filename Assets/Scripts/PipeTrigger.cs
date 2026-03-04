using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
     public Camera mainCamera;
    public float cameraZPosition = -10f;

    public GameObject pipePuzzleRoom;
    void OnMouseDown()
    {
        mainCamera.transform.position = new Vector3( pipePuzzleRoom.transform.position.x,  pipePuzzleRoom.transform.position.y, cameraZPosition);
    }
} 
