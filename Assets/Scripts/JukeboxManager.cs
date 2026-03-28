using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JukeboxManager : MonoBehaviour, IUsableWithItem
{
    public DialogueManager dialogueManager;
    private SpriteRenderer sr;

    public Color hoverColor = Color.red;
    private Color originalColor;

    public TextAsset myInkJSON;

    [Header("Item Drop")]
    public int maxItems = 2;
    public string[] acceptedItemNames = new string[] { "ComputerChip", "Needle" };
    public TextMeshProUGUI counterText;
    public string endSceneName = "WinScreen";

    private int itemCount = 0;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void Start()
    {
        counterText?.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (dialogueManager.dialogueStarted) return;
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;

        dialogueManager.StartDialogue(myInkJSON, null);
    }

    void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    void OnMouseExit()
    {
        sr.color = originalColor;
    }

    public bool UseWithItem(Item item, Vector3 hitPoint)
    {
        if (item == null) return false;
        if (!JukeboxPanelManager.IsOpen) return false;
        if (itemCount >= maxItems) return false;

        bool accepted = false;
        foreach (var name in acceptedItemNames)
        {
            if (item.itemName == name) { accepted = true; break; }
        }
        if (!accepted) return false;

        itemCount++;

        if (counterText != null)
        {
            counterText.gameObject.SetActive(true);
            counterText.text = $"{itemCount}/{maxItems}";
        }

        return true;
    }
}
