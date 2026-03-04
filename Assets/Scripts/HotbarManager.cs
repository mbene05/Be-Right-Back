using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    // All slots that belong to this hotbar (eg. 12)
    public HotbarSlot[] allSlots = new HotbarSlot[12];

    // How many slots are visible at once in the UI (eg. 4)
    public int visibleCount = 4;

    // Start index of the visible window (0-based)
    public int startIndex = 0;

    // If true, pages wrap around when scrolling past ends
    public bool wrapPages = true;

    void Start()
    {
        EnsureSlotsInitialized();
        RefreshVisibleSlots();
    }

    void EnsureSlotsInitialized()
    {
        if (allSlots == null || allSlots.Length == 0)
        {
            var found = GetComponentsInChildren<HotbarSlot>(true);
            if (found != null && found.Length > 0)
            {
                allSlots = new HotbarSlot[found.Length];
                for (int i = 0; i < found.Length; i++) allSlots[i] = found[i];
            }
        }
        else
        {
            // fill null entries from children if possible
            bool hasNull = false;
            foreach (var s in allSlots) if (s == null) { hasNull = true; break; }
            if (hasNull)
            {
                var found = GetComponentsInChildren<HotbarSlot>(true);
                var list = new System.Collections.Generic.List<HotbarSlot>();
                foreach (var f in found) list.Add(f);
                // keep existing non-null in their order, append any others
                for (int i = 0; i < allSlots.Length; i++)
                {
                    if (allSlots[i] == null && list.Count > 0)
                    {
                        allSlots[i] = list[0];
                        list.RemoveAt(0);
                    }
                }
            }
        }
    }

    public bool AddItem(Item item)
    {
        EnsureSlotsInitialized();
        if (allSlots == null || allSlots.Length == 0)
        {
            Debug.LogWarning("HotbarManager: no slots defined to add items to.");
            return false;
        }

       
        for (int i = 0; i < allSlots.Length; i++)
        {
            if (allSlots[i] == null) continue;
            if (IsIndexVisible(i) && allSlots[i].currentItem == null)
            {
                allSlots[i].AddItem(item);
                return true;
            }
        }

        for (int i = 0; i < allSlots.Length; i++)
        {
            var slot = allSlots[i];
            if (slot != null && slot.currentItem == null)
            {
                slot.AddItem(item);
                return true;
            }
        }

        Debug.Log("Hotbar is full!");
        return false;
    }

    public bool HasItem(string itemName)
    {
        foreach (var slot in allSlots)
        {
            if (slot != null && slot.currentItem != null && slot.currentItem.itemName == itemName)
                return true;
        }
        return false;
    }

    public Item GetItemByID(int id)
    {
        foreach (var slot in allSlots)
        {
            if (slot != null && slot.currentItem != null && slot.currentItem.itemID == id)
            {
                return slot.currentItem;
            }
        }
        return null;
    }

    public void ClearSlotAt(int index)
    {
        if (index >= 0 && index < allSlots.Length && allSlots[index] != null)
            allSlots[index].ClearSlot();
    }

    
    public void getridofslot1()
    {
        ClearSlotAt(0);
    }

    public void RefreshVisibleSlots()
    {
        if (allSlots == null || allSlots.Length == 0) return;

        for (int i = 0; i < allSlots.Length; i++)
        {
            if (allSlots[i] == null) continue;
            bool visible = IsIndexVisible(i);
            allSlots[i].gameObject.SetActive(visible);
        }
    }

    bool IsIndexVisible(int index)
    {
        if (visibleCount <= 0) return false;
        if (visibleCount >= allSlots.Length) return true;

        int end = startIndex + visibleCount - 1;
        if (!wrapPages)
        {
            return index >= startIndex && index <= end;
        }
        else
        {
            int wrappedIndex = (index - startIndex + allSlots.Length) % allSlots.Length;
            return wrappedIndex >= 0 && wrappedIndex < visibleCount;
        }
    }

    public void NextPage()
    {
        startIndex = (startIndex + visibleCount) % allSlots.Length;
        RefreshVisibleSlots();
    }

    public void PrevPage()
    {
        startIndex = (startIndex - visibleCount) % allSlots.Length;
        if (startIndex < 0) startIndex += allSlots.Length;
        RefreshVisibleSlots();
    }

    public void SetStartIndex(int index)
    {
        if (allSlots == null || allSlots.Length == 0) return;
        startIndex = Mathf.Clamp(index, 0, allSlots.Length - 1);
        RefreshVisibleSlots();
    }
}