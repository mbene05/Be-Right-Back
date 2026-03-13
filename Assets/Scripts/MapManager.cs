using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public struct RoomLock
{
    public int roomNumber;
    public string requiredItemName;
}

public class MapManager : MonoBehaviour
{
    public RoomSwitcher roomSwitcher;
    private HotbarManager hotbar;

    [Header("Locked Rooms")]
    public RoomLock[] roomLocks;

    [Header("Map UI")]
    public GameObject mapPanel;
    public Button toggleButton;

    [Header("Room Nodes")]
    public Button nodeDiner;
    public Button nodeBathroom;
    public Button nodeKitchen;
    public Button nodeBar;
    public Button nodeKitchenBackroom;
    public Button nodeCoatRoom;
    public Button nodeFoyer;

    [Header("Colors")]
    public Color colorCurrent = Color.white;
    public Color colorAccessible = new Color(0.8f, 0.8f, 0.8f, 1f);
    public Color colorInaccessible = new Color(0.12f, 0.12f, 0.12f, 1f);

    public static bool IsOpen { get; private set; }

    private bool mapOpen = false;
    private CanvasGroup panelGroup;
    private GameObject mapBlocker;
    private Dictionary<int, GameObject> lockIndicators = new Dictionary<int, GameObject>();

    private readonly Dictionary<int, int[]> accessibleFrom = new Dictionary<int, int[]>
    {
        { 1, new[] { 2, 3, 4, 8 } },
        { 2, new[] { 1 } },
        { 3, new[] { 1, 6 } },
        { 4, new[] { 7, 1 } },
        { 6, new[] { 3 } },
        { 7, new[] { 4 } },
        { 8, new[] { 1 } },
    };

    private Dictionary<int, Button> nodes;

    void Start()
    {
        hotbar = FindObjectOfType<HotbarManager>();
        if (roomSwitcher == null) { Debug.LogError("MapManager: roomSwitcher is not assigned."); return; }
        if (mapPanel == null) { Debug.LogError("MapManager: mapPanel is not assigned."); return; }
        if (toggleButton == null) { Debug.LogError("MapManager: toggleButton is not assigned."); return; }
        if (nodeDiner == null) { Debug.LogError("MapManager: nodeDiner is not assigned."); return; }
        if (nodeBathroom == null) { Debug.LogError("MapManager: nodeBathroom is not assigned."); return; }
        if (nodeKitchen == null) { Debug.LogError("MapManager: nodeKitchen is not assigned."); return; }
        if (nodeBar == null) { Debug.LogError("MapManager: nodeBar is not assigned."); return; }
        if (nodeKitchenBackroom == null) { Debug.LogError("MapManager: nodeKitchenBackroom is not assigned."); return; }
        if (nodeCoatRoom == null) { Debug.LogError("MapManager: nodeCoatRoom is not assigned."); return; }
        if (nodeFoyer == null) { Debug.LogError("MapManager: nodeFoyer is not assigned."); return; }

        panelGroup = mapPanel.GetComponent<CanvasGroup>();
        if (panelGroup == null)
            panelGroup = mapPanel.AddComponent<CanvasGroup>();

        nodes = new Dictionary<int, Button>
        {
            { 1, nodeDiner },
            { 2, nodeBathroom },
            { 3, nodeKitchen },
            { 4, nodeBar },
            { 6, nodeKitchenBackroom },
            { 7, nodeCoatRoom },
            { 8, nodeFoyer },
        };

        nodeDiner.onClick.AddListener(() => NavigateTo(1));
        nodeBathroom.onClick.AddListener(() => NavigateTo(2));
        nodeKitchen.onClick.AddListener(() => NavigateTo(3));
        nodeBar.onClick.AddListener(() => NavigateTo(4));
        nodeKitchenBackroom.onClick.AddListener(() => NavigateTo(6));
        nodeCoatRoom.onClick.AddListener(() => NavigateTo(7));
        nodeFoyer.onClick.AddListener(() => NavigateTo(8));

        toggleButton.onClick.AddListener(ToggleMap);

        SetupMapLayout();
        CreateLockIndicators();
        SetPanelVisible(false);
        RefreshMap();
    }

    void SetupMapLayout()
    {
        Canvas panelCanvas = mapPanel.GetComponent<Canvas>();
        if (panelCanvas == null) panelCanvas = mapPanel.AddComponent<Canvas>();
        panelCanvas.overrideSorting = true;
        panelCanvas.sortingOrder = 100;
        if (mapPanel.GetComponent<GraphicRaycaster>() == null)
            mapPanel.AddComponent<GraphicRaycaster>();

        mapBlocker = new GameObject("MapBlocker");
        mapBlocker.transform.SetParent(mapPanel.transform.parent, false);

        Image blockerImg = mapBlocker.AddComponent<Image>();
        blockerImg.color = new Color(0f, 0f, 0f, 0f);
        blockerImg.raycastTarget = true;

        Canvas blockerCanvas = mapBlocker.AddComponent<Canvas>();
        blockerCanvas.overrideSorting = true;
        blockerCanvas.sortingOrder = 99;
        mapBlocker.AddComponent<GraphicRaycaster>();

        RectTransform blockerRT = mapBlocker.GetComponent<RectTransform>();
        blockerRT.anchorMin = Vector2.zero;
        blockerRT.anchorMax = Vector2.one;
        blockerRT.offsetMin = Vector2.zero;
        blockerRT.offsetMax = Vector2.zero;

        mapBlocker.SetActive(false);

        RectTransform panelRT = mapPanel.GetComponent<RectTransform>();
        panelRT.anchorMin = new Vector2(0.5f, 0.5f);
        panelRT.anchorMax = new Vector2(0.5f, 0.5f);
        panelRT.pivot = new Vector2(0.5f, 0.5f);
        panelRT.anchoredPosition = Vector2.zero;
        panelRT.sizeDelta = new Vector2(520, 310);

        Image panelImg = mapPanel.GetComponent<Image>();
        if (panelImg != null)
            panelImg.color = new Color(0.05f, 0.05f, 0.05f, 0.95f);

        SetNodeTransform(nodeKitchenBackroom, -170f,   110f,  110f,  70f);
        SetNodeTransform(nodeKitchen,           -7.5f,  110f,  215f,  70f);
        SetNodeTransform(nodeBar,             -170f,    12.5f, 110f, 125f);
        SetNodeTransform(nodeDiner,             -7.5f,   12.5f, 250f, 150f);
        SetNodeTransform(nodeBathroom,         152.5f,   12.5f, 105f, 125f);
        SetNodeTransform(nodeCoatRoom,        -170f,   -87.5f, 110f,  75f);
        SetNodeTransform(nodeFoyer,             -7.5f,  -87.5f, 215f,  75f);
    }

    void SetNodeTransform(Button node, float x, float y, float w, float h)
    {
        RectTransform rt = node.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.anchoredPosition = new Vector2(x, y);
        rt.sizeDelta = new Vector2(w, h);

        node.transition = Selectable.Transition.None;

        if (node.TryGetComponent(out Image border))
        {
            border.sprite = null;
            border.type   = Image.Type.Simple;
            border.color  = colorInaccessible;
        }

        if (node.transform.Find("MapRoomFill") == null)
        {
            GameObject fill = new GameObject("MapRoomFill");
            fill.transform.SetParent(node.transform, false);
            fill.transform.SetSiblingIndex(0);

            Image fillImg = fill.AddComponent<Image>();
            fillImg.color = new Color(0.07f, 0.07f, 0.07f, 0.95f);
            fillImg.raycastTarget = false;

            RectTransform fillRT = fill.GetComponent<RectTransform>();
            fillRT.anchorMin = Vector2.zero;
            fillRT.anchorMax = Vector2.one;
            fillRT.offsetMin = new Vector2(2f, 2f);
            fillRT.offsetMax = new Vector2(-2f, -2f);
        }

        foreach (var txt in node.GetComponentsInChildren<Text>(true))
        {
            txt.alignment = TextAnchor.MiddleCenter;
            txt.resizeTextForBestFit = true;
            txt.resizeTextMinSize = 7;
            txt.resizeTextMaxSize = 12;
            txt.color = Color.white;
        }

        foreach (var tmp in node.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.enableAutoSizing = true;
            tmp.fontSizeMin = 7;
            tmp.fontSizeMax = 12;
            tmp.color = Color.white;
        }
    }

    void CreateLockIndicators()
    {
        if (roomLocks == null) return;
        foreach (var roomLock in roomLocks)
        {
            if (!nodes.ContainsKey(roomLock.roomNumber)) continue;
            Button node = nodes[roomLock.roomNumber];

            GameObject lockObj = new GameObject("LockIndicator");
            lockObj.transform.SetParent(node.transform, false);
            lockObj.transform.SetAsLastSibling();

            Image bg = lockObj.AddComponent<Image>();
            bg.color = new Color(0f, 0f, 0f, 0.55f);
            bg.raycastTarget = false;

            RectTransform rt = lockObj.GetComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;

            GameObject textObj = new GameObject("LockText");
            textObj.transform.SetParent(lockObj.transform, false);

            TextMeshProUGUI tmp = textObj.AddComponent<TextMeshProUGUI>();
            tmp.text = "X";
            tmp.fontSize = 24;
            tmp.fontStyle = FontStyles.Bold;
            tmp.color = new Color(0.9f, 0.15f, 0.15f, 1f);
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.raycastTarget = false;

            RectTransform textRt = textObj.GetComponent<RectTransform>();
            textRt.anchorMin = Vector2.zero;
            textRt.anchorMax = Vector2.one;
            textRt.offsetMin = Vector2.zero;
            textRt.offsetMax = Vector2.zero;

            lockIndicators[roomLock.roomNumber] = lockObj;
        }
    }

    void SetPanelVisible(bool visible)
    {
        IsOpen = visible;
        panelGroup.alpha = visible ? 1f : 0f;
        panelGroup.interactable = visible;
        panelGroup.blocksRaycasts = visible;

        mapBlocker?.SetActive(visible);
    }

    public void ToggleMap()
    {
        mapOpen = !mapOpen;
        SetPanelVisible(mapOpen);

        if (mapOpen)
            RefreshMap();
    }

    public void RefreshMap()
    {
        if (nodes == null) return;

        int current = roomSwitcher.currentRoom;
        int[] accessible = accessibleFrom.ContainsKey(current) ? accessibleFrom[current] : new int[0];

        foreach (var kvp in nodes)
        {
            int id = kvp.Key;
            Button node = kvp.Value;
            if (node == null) continue;

            if (id == current)
                ApplyState(node, colorCurrent, false);
            else if (System.Array.IndexOf(accessible, id) >= 0)
                ApplyState(node, colorAccessible, true);
            else
                ApplyState(node, colorInaccessible, false);
        }

        // Show/hide lock indicators
        if (roomLocks != null)
        {
            foreach (var roomLock in roomLocks)
            {
                if (!lockIndicators.ContainsKey(roomLock.roomNumber)) continue;
                bool isLocked = hotbar == null || !hotbar.HasItem(roomLock.requiredItemName);
                lockIndicators[roomLock.roomNumber].SetActive(isLocked);
            }
        }
    }

    void ApplyState(Button node, Color borderColor, bool interactable)
    {
        node.interactable = interactable;

        bool dark = !interactable && borderColor != colorCurrent;
        Color fillColor = dark ? new Color(0.04f, 0.04f, 0.04f, 0.95f) : new Color(0.07f, 0.07f, 0.07f, 0.95f);
        Color textColor = dark ? new Color(0.25f, 0.25f, 0.25f, 1f) : Color.white;

        if (node.TryGetComponent(out Image border))
            border.color = borderColor;

        Transform fill = node.transform.Find("MapRoomFill");
        if (fill != null && fill.TryGetComponent(out Image fillImg))
            fillImg.color = fillColor;

        foreach (var txt in node.GetComponentsInChildren<Text>(true))
            txt.color = textColor;

        foreach (var tmp in node.GetComponentsInChildren<TextMeshProUGUI>(true))
            tmp.color = textColor;
    }
    void NavigateTo(int roomId)
    {
        if (roomLocks != null && hotbar != null)
        {
            foreach (var roomLock in roomLocks)
            {
                if (roomLock.roomNumber == roomId && !hotbar.HasItem(roomLock.requiredItemName))
                {
                    Debug.Log("You need a " + roomLock.requiredItemName + " to enter here.");
                    return;
                }
            }
        }

        mapOpen = false;
        SetPanelVisible(false);

        switch (roomId)
        {
            case 1: roomSwitcher.ShowRoom1(); break;
            case 2: roomSwitcher.ShowRoom2(); break;
            case 3: roomSwitcher.ShowRoom3(); break;
            case 4: roomSwitcher.ShowBar(); break;
            case 6: roomSwitcher.ShowKitchenBackroom(); break;
            case 7: roomSwitcher.ShowCoatRoom(); break;
            case 8: roomSwitcher.ShowFoyer(); break;
        }
    }
}
