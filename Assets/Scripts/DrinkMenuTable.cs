using UnityEngine;

public class DrinkMenu : MonoBehaviour
{
    public GameObject menuPanel; // Assign your Panel in Inspector
    public bool HasClicked = false;
    
     private SpriteRenderer sr;

    public GameObject highlighted;

    void Start()
    {
        // Make sure menu is hidden at start
        menuPanel.SetActive(false);
    }

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;

        HasClicked = true;
        Debug.Log("Menu object activated");
        // Toggle the menu on click
        menuPanel.SetActive(true);
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        highlighted.SetActive(true);
    }

    void OnMouseExit()
    {
        highlighted.SetActive(false);
    }
}
