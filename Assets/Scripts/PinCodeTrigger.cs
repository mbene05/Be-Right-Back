using UnityEngine;

public class PinCodeTrigger : MonoBehaviour
//sum like this on the door to trigger the pin code mini game yeah
{
    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        PinCodeMiniGame.Instance.Open();
    }
}
