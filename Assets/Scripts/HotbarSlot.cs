using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class HotbarSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image itemIcon;
    public Item currentItem;

    public Canvas parentCanvas;

    private GameObject dragIconObject;
    private Image dragIconImage;

    private Item draggingItem;

    void Awake()
    {
        if (parentCanvas == null)
        {
            parentCanvas = GetComponentInParent<Canvas>();
        }
    }

    public void AddItem(Item newItem)
    {
        currentItem = newItem;
        if (itemIcon != null)
        {
            itemIcon.sprite = newItem.itemSprite;
            itemIcon.enabled = true;
        }
    }

    public void ClearSlot()
    {
        currentItem = null;
        if (itemIcon != null)
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;

        draggingItem = currentItem;

        dragIconObject = new GameObject("HotbarDragIcon");
        dragIconObject.transform.SetParent(parentCanvas.transform, false);
        dragIconObject.transform.SetAsLastSibling();

        dragIconImage = dragIconObject.AddComponent<Image>();
        dragIconImage.raycastTarget = false;
        dragIconImage.sprite = itemIcon.sprite;
        dragIconImage.SetNativeSize();

        if (itemIcon != null)
        {
            itemIcon.enabled = false;
        }

        currentItem = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragIconObject == null) return;

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            eventData.position,
            parentCanvas.worldCamera,
            out pos);

        dragIconObject.transform.localPosition = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragIconObject != null)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = eventData.position;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            HotbarSlot targetSlot = null;
            IUsableWithItem uiDropTarget = null;
            foreach (var hit in results)
            {
                if (targetSlot == null)
                    targetSlot = hit.gameObject.GetComponentInParent<HotbarSlot>();
                if (uiDropTarget == null)
                    uiDropTarget = hit.gameObject.GetComponentInParent<IUsableWithItem>();
                if (targetSlot != null && uiDropTarget != null) break;
            }

            bool consumed = false;

            if (uiDropTarget != null && !(uiDropTarget is HotbarSlot))
            {
                consumed = uiDropTarget.UseWithItem(draggingItem, Vector3.zero);
                if (!consumed) AddItem(draggingItem);
            }
            else if (targetSlot != null && targetSlot != this)
            {
                Item targetItem = targetSlot.currentItem;
                targetSlot.AddItem(draggingItem);
                if (targetItem != null)
                {
                    AddItem(targetItem);
                }
                else
                {
                    ClearSlot();
                }
                consumed = true;
            }
            else
            {
                Camera cam = parentCanvas != null && parentCanvas.worldCamera != null ? parentCanvas.worldCamera : Camera.main;
                if (cam != null)
                {
                    Ray ray = cam.ScreenPointToRay(eventData.position);
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo, 100f))
                    {
                        var usable = hitInfo.collider.GetComponentInParent<IUsableWithItem>();
                        if (usable != null)
                        {
                            if (usable.UseWithItem(draggingItem, hitInfo.point))
                            {
                                consumed = true;
                            }
                        }
                    }

                    if (!consumed)
                    {
                        Vector2 worldPos2D = cam.ScreenToWorldPoint(eventData.position);
                        RaycastHit2D hit2D = Physics2D.Raycast(worldPos2D, Vector2.zero);
                        if (hit2D.collider != null)
                        {
                            var usable = hit2D.collider.GetComponentInParent<IUsableWithItem>();
                            if (usable != null)
                            {
                                if (usable.UseWithItem(draggingItem, hit2D.point))
                                {
                                    consumed = true;
                                }
                            }
                        }
                    }
                }

                if (!consumed)
                {
                    AddItem(draggingItem);
                }
            }

            GameObject.Destroy(dragIconObject);
            dragIconObject = null;
            dragIconImage = null;
            draggingItem = null;
        }
    }
}