using UnityEngine;

public class RecipeTable : MonoBehaviour
{

    public GameObject recipePanel; // Assign your Panel in Inspector
    public bool HasClicked = false;
    
     private SpriteRenderer sr;


    void Start()
    {
        // Make sure menu is hidden at start
        recipePanel.SetActive(false);
    }

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;

        HasClicked = true;
        Debug.Log("Menu object activated");
        // Toggle the menu on click
        recipePanel.SetActive(true);
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
   
}
