using UnityEngine;

public class BackScript : MonoBehaviour
{
   
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public GameObject tilereturnRoom;
    public GameObject trigger;
    public GameObject Arrow;
    public GameObject Arrow2;

    void OnMouseDown()
    {
        Arrow.SetActive(true);
        Arrow2.SetActive(true);
        trigger.GetComponent<TilePuzzleTrigger>().isOpen = false;
        mainCamera.transform.position = new Vector3(tilereturnRoom.transform.position.x, tilereturnRoom.transform.position.y, cameraZPosition);
    }
}
