using UnityEngine;

public class BackScript : MonoBehaviour
{
   
    public Camera mainCamera;
    public float cameraZPosition = -10f;

    public GameObject tilePuzzleRoom;
    void OnMouseDown()
    {
        mainCamera.transform.position = new Vector3(tilePuzzleRoom.transform.position.x, tilePuzzleRoom.transform.position.y, cameraZPosition);
    }
}
