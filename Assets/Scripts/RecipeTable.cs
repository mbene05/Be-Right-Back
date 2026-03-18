using UnityEngine;

public class RecipeTable : MonoBehaviour
{

    public GameObject recipePanel; // Assign your Panel in Inspector
    public bool HasClicked = false;
    
     private SpriteRenderer sr;

    public Color hoverColor = Color.red;
    private Color originalColor;


    void Start()
    {
        // Make sure menu is hidden at start
        recipePanel.SetActive(false);
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    void OnMouseExit()
    {
        sr.color = originalColor;
    }

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;

        HasClicked = true;
        Debug.Log("Menu object activated");
        // Toggle the menu on click
        recipePanel.SetActive(true);
    }

   
}
