using UnityEngine;

public class PinCodeTrigger : MonoBehaviour
//sum like this on the door to trigger the pin code mini game yeah
{
     public GameObject backButton;
     public GameObject pinCode;
    void OnMouseDown()
    {
        if (pinCode.GetComponent<PinCodeMiniGame>().won == true) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;
        PinCodeMiniGame.Instance.Open();
        backButton.SetActive(true);
    }
}
