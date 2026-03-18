using UnityEngine;

public class JukeboxTrigger : MonoBehaviour
{
    public GameObject jukeboxPanelObject;

    void OnMouseDown()
    {
        if (JukeboxPanelManager.Instance.IsDone) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;

        JukeboxPanelManager.Instance.Open();
    }
}
