using UnityEngine;

public class MazeTrigger : MonoBehaviour
{
    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;
        MazeMiniGame.Instance.Open();
    }
}
