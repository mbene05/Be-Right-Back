using UnityEngine;

// Attach to each nav button under Canvas.
// Show In Room:  which room this button is visible in.
// Required Item: leave empty for unlocked rooms, or enter the item name needed to unlock.
public class RoomNavButton : MonoBehaviour
{
    public int showInRoom;
     public DialogueManager dialogueManager;
    public string requiredItem = "";
    public GameObject phone;

    private CanvasGroup _group;
    public TextAsset myInkJSON; 
    private RoomSwitcher _switcher;
    private HotbarManager _hotbar;
    private bool _locked;

    void Awake()
    {
        _group = GetComponent<CanvasGroup>();
        if (_group == null) _group = gameObject.AddComponent<CanvasGroup>();
        SetVisible(false, false);
    }

    void Start()
    {
        _switcher = FindObjectOfType<RoomSwitcher>();
        _hotbar   = FindObjectOfType<HotbarManager>();
    }

    void Update()
    {
        if (_switcher == null) return;

        bool inRoom  = _switcher.currentRoom == showInRoom;
        bool itemOk  = string.IsNullOrEmpty(requiredItem) || (_hotbar != null && _hotbar.HasItem(requiredItem));
        bool suppress = DialogueManager.IsOpen || DialogueManager.choicesActive || RoomSwitcher.IsTransitioning || phone.GetComponent<PhoneScript>().HasClicked == true;

        _locked = !itemOk;

        if (!inRoom || suppress)
            SetVisible(false, false);
        else if (_locked)
            SetVisible(true, false);
        else
            SetVisible(true, true);
    }


    void SetVisible(bool visible, bool interactable)
    {
        _group.alpha = visible ? (_locked ? 0.35f : 1f) : 0f;
        _group.interactable = interactable;
        _group.blocksRaycasts = visible;
    }
}
