using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    public Camera mainCamera;
    private SpriteRenderer sr;

    public Color hoverColor = Color.red;
    private Color originalColor;
    public float cameraZPosition = -10f;
    public DialogueManager dialogueManager;
    public GameObject pipePuzzleRoom;
    public GameObject returnRoom;
    public string requiredItemName = "Wrench";
    private HotbarManager hotbar;
    public TextAsset myInkJSON;
    
    public bool isOpen = false;
    public GameObject Arrow;
    public GameObject Arrow2;

    void Start()
    {
        hotbar = FindObjectOfType<HotbarManager>();
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
        if (dialogueManager.dialogueStarted) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;
        if (isOpen) return;

        if (hotbar != null && !hotbar.HasItem(requiredItemName))
        {
            if (dialogueManager.dialogueStarted) return;
            if (MapManager.IsOpen) return;
            if (PinCodeMiniGame.IsOpen) return;
            if (RoomSwitcher.IsTransitioning) return;
            dialogueManager.StartDialogue(myInkJSON, null);
            return;
        }
        Arrow.SetActive(false);
        Arrow2.SetActive(false);
        if (hotbar != null) hotbar.gameObject.SetActive(false);

        isOpen = true;
        mainCamera.transform.position = new Vector3(pipePuzzleRoom.transform.position.x, pipePuzzleRoom.transform.position.y, cameraZPosition);
        

    }

    void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            Arrow.SetActive(true);
            Arrow2.SetActive(true);
            if (hotbar != null) hotbar.gameObject.SetActive(true);
            isOpen = false;
            mainCamera.transform.position = new Vector3(returnRoom.transform.position.x, returnRoom.transform.position.y, cameraZPosition);
        }
    }
}