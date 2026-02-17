using UnityEngine;
using UnityEngine.EventSystems;


public class HotbarScroller : MonoBehaviour, IScrollHandler
{
    public HotbarManager hotbarManager;

    public void OnScroll(PointerEventData eventData)
    {
        if (hotbarManager == null) return;

        if (eventData.scrollDelta.y > 0)
        {
            hotbarManager.PrevPage();
        }
        else if (eventData.scrollDelta.y < 0)
        {
            hotbarManager.NextPage();
        }
    }

    void Update()
    {
        if (hotbarManager == null) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            hotbarManager.PrevPage();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            hotbarManager.NextPage();
        }
    }
}
