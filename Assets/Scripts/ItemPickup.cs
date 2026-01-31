using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; // The Item ScriptableObject this pickup represents
    public Hotbar hotbar; // Reference to the hotbar

    void Start()
    {
        // Find the hotbar in the scene if not assigned
        if (hotbar == null)
        {
            hotbar = FindObjectOfType<Hotbar>();
        }
    }

    void OnMouseDown()
    {
        // When clicked, try to add to hotbar
        if (hotbar != null && item != null)
        {
            bool success = hotbar.AddItem(item);
            
            if (success)
            {
                Debug.Log("Picked up: " + item.itemName);
                // Hide or destroy the pickup
                gameObject.SetActive(false); // Or use Destroy(gameObject);
            }
            else
            {
                Debug.Log("Hotbar is full!");
            }
        }
    }
}