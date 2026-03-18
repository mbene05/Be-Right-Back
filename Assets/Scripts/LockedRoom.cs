using UnityEngine;

public class LockedRoom : MonoBehaviour
{
    public string requiredItemName;  // Item name needed to enter (must match Item.itemName exactly)
    public int targetRoomNumber;     // Room number to transition to

    private RoomSwitcher roomSwitcher;
    private HotbarManager hotbar;

    void Start()
    {
        roomSwitcher = FindObjectOfType<RoomSwitcher>();
        hotbar = FindObjectOfType<HotbarManager>();
    }

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;

        if (hotbar.HasItem(requiredItemName))
        {
            roomSwitcher.GoToRoom(targetRoomNumber);
        }
        else
        {
            Debug.Log("You need a " + requiredItemName + " to enter here.");
        }
    }
}
