using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    public Image itemIcon;
    public Item currentItem;

    public void AddItem(Item newItem)
    {
        currentItem = newItem;
        itemIcon.sprite = newItem.itemSprite;
        itemIcon.enabled = true;
    }

    public void ClearSlot()
    {
        currentItem = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }
}