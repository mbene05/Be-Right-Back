using UnityEngine;

public class BackScriptPipe : MonoBehaviour
{
   
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public GameObject tilereturnRoom;
    public GameObject trigger;

    void OnMouseDown()
    {
        trigger.GetComponent<PipeTrigger>().isOpen = false;
        mainCamera.transform.position = new Vector3(tilereturnRoom.transform.position.x, tilereturnRoom.transform.position.y, cameraZPosition);
    }
}
