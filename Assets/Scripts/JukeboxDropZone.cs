using UnityEngine;
using UnityEngine.UI;

public class JukeboxDropZone : MonoBehaviour, IUsableWithItem
{
    public enum ZoneType { Needle, ComputerChip }
    public ZoneType zoneType;

    void Awake()
    {
        // Ensure the zone is hittable by UI raycasts
        Image img = GetComponent<Image>();
        if (img == null) img = gameObject.AddComponent<Image>();
        img.color = new Color(0f, 0f, 0f, 0f);
        img.raycastTarget = true;
    }

    public bool UseWithItem(Item item, Vector3 hitPoint)
    {
        if (item == null) return false;
        if (JukeboxPanelManager.Instance == null) return false;
        if (!JukeboxPanelManager.IsOpen) return false;

        if (zoneType == ZoneType.Needle && item.itemName == "Needle")
        {
            JukeboxPanelManager.Instance.PlaceNeedle();
            return true;
        }
        if (zoneType == ZoneType.ComputerChip && item.itemName == "ComputerChip")
        {
            JukeboxPanelManager.Instance.PlaceChip();
            return true;
        }

        return false;
    }
}
