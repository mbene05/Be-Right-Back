using UnityEngine;

public class JukeboxTrigger : MonoBehaviour
{
    public GameObject jukeboxPanelObject;
    public bool alwayshasAccess = false;
    void OnMouseDown()
    {
        if (JukeboxPanelManager.Instance.IsDone) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;

        HotbarManager hotbar = FindObjectOfType<HotbarManager>();
        if (hotbar == null) return;
        
        if (alwayshasAccess == false)
        {
            if (!hotbar.HasItem("Needle") || !hotbar.HasItem("ComputerChip")) return;
        }

        JukeboxPanelManager.Instance.Open();
    }
}
