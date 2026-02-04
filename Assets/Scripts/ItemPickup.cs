using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; // The Item ScriptableObject this pickup represents
    public Hotbar hotbar; // Reference to the hotbar
    public bool isLimitedPickup = false; // Check this for the 4 special items
    public string limitedGroupID = "drinks"; // Group ID for items that share the limit
    
    private static System.Collections.Generic.Dictionary<string, GameObject> limitedPickups = new System.Collections.Generic.Dictionary<string, GameObject>();

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
        // If this is a limited pickup item, check if one from the same group is already picked
        if (isLimitedPickup)
        {
            if (limitedPickups.ContainsKey(limitedGroupID) && limitedPickups[limitedGroupID] != null)
            {
                Debug.Log("You already have a " + limitedGroupID + " item! Use or drop it first.");
                return;
            }
        }

        // When clicked, try to add to hotbar
        if (hotbar != null && item != null)
        {
            bool success = hotbar.AddItem(item);
            
            if (success)
            {
                Debug.Log("Picked up: " + item.itemName);
                
                // If this is a limited pickup, register it
                if (isLimitedPickup)
                {
                    limitedPickups[limitedGroupID] = gameObject;
                }
                
                // Hide the pickup
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Hotbar is full!");
            }
        }
    }
    
    // Call this method when a limited item is used/destroyed
    public static void ClearLimitedItem(string groupID)
    {
        if (limitedPickups.ContainsKey(groupID) && limitedPickups[groupID] != null)
        {
            Destroy(limitedPickups[groupID]);
            limitedPickups[groupID] = null;
            limitedPickups.Remove(groupID);
            Debug.Log("Limited item from group '" + groupID + "' destroyed. You can now pick up another from this group.");
        }
    }
    
    // Check if a limited item from a specific group is currently held
    public static bool HasLimitedItem(string groupID)
    {
        return limitedPickups.ContainsKey(groupID) && limitedPickups[groupID] != null;
    }
    
    // Get the current limited item from a specific group
    public static GameObject GetLimitedItem(string groupID)
    {
        if (limitedPickups.ContainsKey(groupID))
        {
            return limitedPickups[groupID];
        }
        return null;
    }
}