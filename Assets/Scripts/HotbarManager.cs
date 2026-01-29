using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public HotbarSlot[] slots = new HotbarSlot[6];

    public bool AddItem(Item item)
    {
        // Find first empty slot
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].currentItem == null)
            {
                slots[i].AddItem(item);
                return true;
            }
        }
        Debug.Log("Hotbar is full!");
        return false;
    }

    public Item GetItemByID(int id)
    {
        foreach (var slot in slots)
        {
            if (slot.currentItem != null && slot.currentItem.itemID == id)
            {
                return slot.currentItem;
            }
        }
        return null;
    }
}