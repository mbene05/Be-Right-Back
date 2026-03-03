using UnityEngine;

public class MazeTrigger : MonoBehaviour
{
    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        MazeMiniGame.Instance.Open();
    }
}
