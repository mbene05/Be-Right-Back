using UnityEngine;

public class BackScriptPipe : MonoBehaviour
{

    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public GameObject tilereturnRoom;
    public GameObject trigger;
    public GameObject Arrow;

    void OnMouseDown()
    {
        Arrow.SetActive(true);
        trigger.GetComponent<PipeTrigger>().isOpen = false;
        mainCamera.transform.position = new Vector3(tilereturnRoom.transform.position.x, tilereturnRoom.transform.position.y, cameraZPosition);
    }
}
