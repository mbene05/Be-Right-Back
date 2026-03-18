using UnityEngine;
using UnityEngine.EventSystems;

public class DrinkMenu : MonoBehaviour
{
    public GameObject menuPanel; // Assign your Panel in Inspector
    public bool HasClicked = false;

    private SpriteRenderer sr;
    private int openTimer = 0;

    public GameObject highlighted;

    void Start()
    {
        // Make sure menu is hidden at start
        menuPanel.SetActive(false);
    }
    void Update()
    {
        if (menuPanel.activeSelf && Input.GetMouseButtonDown(0) && openTimer > 5)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                menuPanel.SetActive(false);
                openTimer = 0;
            }
        }
        if (menuPanel.activeSelf)
            openTimer++;
    }

    void OnMouseDown()
    {
        highlighted.SetActive(false);

        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;

        HasClicked = true;
        openTimer = 0;
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
        if (menuPanel.activeInHierarchy)
        {
            highlighted.SetActive(false);
        }
        else
        {
            highlighted.SetActive(true);
        }
           
    }

    void OnMouseExit()
    {
        highlighted.SetActive(false);
    }
}
