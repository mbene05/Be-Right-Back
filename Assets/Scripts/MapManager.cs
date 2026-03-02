using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{
    public RoomSwitcher roomSwitcher;

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
    public Color colorAccessible = new Color(0.6f, 0.6f, 0.6f, 1f);
    public Color colorInaccessible = new Color(0.4f, 0.4f, 0.4f, 1f);

    public static bool IsOpen { get; private set; }

    private bool mapOpen = false;
    private CanvasGroup panelGroup;
    private GameObject mapBlocker;

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
        SetPanelVisible(false);
        RefreshMap();
    }

    void SetupMapLayout()
    {
        // Create a full-screen blocker that sits behind the map panel.
        // This prevents clicks from reaching anything outside the map while it's open.
        // Give mapPanel its own Canvas so it overrides sort order and always renders on top.
        Canvas panelCanvas = mapPanel.GetComponent<Canvas>();
        if (panelCanvas == null) panelCanvas = mapPanel.AddComponent<Canvas>();
        panelCanvas.overrideSorting = true;
        panelCanvas.sortingOrder = 100;
        if (mapPanel.GetComponent<GraphicRaycaster>() == null)
            mapPanel.AddComponent<GraphicRaycaster>();

        // Blocker sits just below the map panel in sort order.
        mapBlocker = new GameObject("MapBlocker");
        mapBlocker.transform.SetParent(mapPanel.transform.parent, false);

        Image blockerImg = mapBlocker.AddComponent<Image>();
        blockerImg.color = new Color(0f, 0f, 0f, 0f); // fully transparent but catches raycasts
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
        panelRT.sizeDelta = new Vector2(480, 300);

        Image panelImg = mapPanel.GetComponent<Image>();
        if (panelImg != null)
            panelImg.color = new Color(0.05f, 0.05f, 0.05f, 0.95f);

        SetNodeTransform(nodeKitchenBackroom,  -90, 100);
        SetNodeTransform(nodeKitchen,           80, 100);
        SetNodeTransform(nodeBar,             -190,   0);
        SetNodeTransform(nodeDiner,              0,   0);
        SetNodeTransform(nodeBathroom,         190,   0);
        SetNodeTransform(nodeCoatRoom,        -190, -100);
        SetNodeTransform(nodeFoyer,              0, -100);
    }

    void SetNodeTransform(Button node, float x, float y)
    {
        RectTransform rt = node.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.anchoredPosition = new Vector2(x, y);
        rt.sizeDelta = new Vector2(100, 36);
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
    }

    void ApplyState(Button node, Color color, bool interactable)
    {
        node.interactable = interactable;

        foreach (var img in node.GetComponentsInChildren<Image>(true))
            img.color = color;

        foreach (var txt in node.GetComponentsInChildren<Text>(true))
            txt.color = color;
    }

    void NavigateTo(int roomId)
    {
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
