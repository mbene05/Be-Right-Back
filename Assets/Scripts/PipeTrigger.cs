using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    public Camera mainCamera;
    private SpriteRenderer sr;

    public Color hoverColor = Color.red;
    private Color originalColor;
    public float cameraZPosition = -10f;
    public GameObject pipePuzzleRoom;
    public GameObject returnRoom;
    public string requiredItemName = "Wrench";
    private MapManager mapManager;

    private HotbarManager hotbar;
    private bool isOpen = false;

    void Start()
    {
        hotbar = FindObjectOfType<HotbarManager>();
        mapManager = FindObjectOfType<MapManager>();
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
        if (isOpen) return;

        if (hotbar != null && !hotbar.HasItem(requiredItemName))
        {
            Debug.Log("You need a " + requiredItemName + " to access this.");
            return;
        }

        isOpen = true;
         mapManager.toggleButton.interactable = false;
       
        mainCamera.transform.position = new Vector3(pipePuzzleRoom.transform.position.x, pipePuzzleRoom.transform.position.y, cameraZPosition);
        

    }

    void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = false;
             mapManager.toggleButton.interactable =true;
            mainCamera.transform.position = new Vector3(returnRoom.transform.position.x, returnRoom.transform.position.y, cameraZPosition);
        }
    }
}