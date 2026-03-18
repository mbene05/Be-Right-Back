using UnityEngine;

public class BackScriptPin : MonoBehaviour
{
   
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public GameObject tilereturnRoom;
    public GameObject trigger;
    

    void OnMouseDown()
    {
        PinCodeMiniGame triggerScript = trigger.GetComponent<PinCodeMiniGame>();
        if (triggerScript != null)
        {
            triggerScript.Close();
        }
         gameObject.SetActive(false);
       
        mainCamera.transform.position = new Vector3(tilereturnRoom.transform.position.x, tilereturnRoom.transform.position.y, cameraZPosition);
    }
}
