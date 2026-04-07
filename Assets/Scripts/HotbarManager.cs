using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    [Header("Tooltip")]
    public TMP_Text tooltipLabel;

    TMP_Text CreateTooltipLabel()
    {
        var obj = new GameObject("HotbarTooltip");
        obj.transform.SetParent(transform, false);

        // Ignore layout so the hotbar's Layout Group doesn't squish it
        var le = obj.AddComponent<LayoutElement>();
        le.ignoreLayout = true;

        var text = obj.AddComponent<TextMeshProUGUI>();
        text.alignment = TextAlignmentOptions.Center;
        text.fontSize = 14;
        text.color = Color.white;

        var rt = obj.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(120, 24);
        rt.pivot = new Vector2(0.5f, 1f); // top-center pivot so it hangs below the slot

        return text;
    }

    public void ShowTooltip(string itemName, RectTransform slotRect)
    {
        if (tooltipLabel == null) return;
        tooltipLabel.text = itemName;

        // Position tooltip below the bottom-center of the hovered slot
        RectTransform tooltipRT = tooltipLabel.rectTransform;
        Transform tooltipParent = tooltipRT.parent;
        if (tooltipParent != null)
        {
            Vector3[] corners = new Vector3[4];
            slotRect.GetWorldCorners(corners);
            Vector3 bottomCenter = (corners[0] + corners[3]) / 2f;
            Vector3 localPos = tooltipParent.InverseTransformPoint(bottomCenter);
            tooltipRT.localPosition = new Vector3(localPos.x, localPos.y - 4f, 0f);
        }

        tooltipLabel.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        if (tooltipLabel == null) return;
        tooltipLabel.gameObject.SetActive(false);
    }

    void Start()
    {
        Canvas c = GetComponent<Canvas>();
        if (c == null) c = gameObject.AddComponent<Canvas>();
        c.overrideSorting = true;
        c.sortingOrder = 999;
        if (GetComponent<GraphicRaycaster>() == null)
            gameObject.AddComponent<GraphicRaycaster>();

        if (tooltipLabel == null)
            tooltipLabel = CreateTooltipLabel();
        HideTooltip();
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