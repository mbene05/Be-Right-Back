using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JukeboxPanelManager : MonoBehaviour
{
    public static JukeboxPanelManager Instance { get; private set; }
    public static bool IsOpen { get; private set; }
    public bool IsDone { get; private set; }

    [Header("Panel")]
    public GameObject jukeboxPanel;

    [Header("Draggable Items")]
    public RectTransform needle;
    public RectTransform computerChip;

    [Header("Drop Zones (Invisible Boxes)")]
    public RectTransform needleDropZone;
    public RectTransform chipDropZone;

    [Header("On Complete")]
    public string winSceneName = "WinScreen";

    [Header("Audio")]
    public AudioClip successSound;
    private AudioSource audioSource;

    private Vector2 needleStartPos;
    private Vector2 chipStartPos;
    private bool needlePlaced = false;
    private bool chipPlaced = false;

    private Canvas canvas;
    private Camera uiCamera;
    private GameObject panelBlocker;

    private RectTransform dragging = null;
    private Vector2 dragOffset;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canvas = jukeboxPanel.GetComponentInParent<Canvas>();
        uiCamera = canvas ? canvas.worldCamera : null;

        needleStartPos = needle.anchoredPosition;
        chipStartPos = computerChip.anchoredPosition;

        // Force panel to render on top
        Canvas panelCanvas = jukeboxPanel.GetComponent<Canvas>();
        if (panelCanvas == null) panelCanvas = jukeboxPanel.AddComponent<Canvas>();
        panelCanvas.overrideSorting = true;
        panelCanvas.sortingOrder = 200;
        if (jukeboxPanel.GetComponent<GraphicRaycaster>() == null)
            jukeboxPanel.AddComponent<GraphicRaycaster>();

        // Full-screen blocker
        panelBlocker = new GameObject("JukeboxBlocker");
        panelBlocker.transform.SetParent(jukeboxPanel.transform.parent, false);

        Image blockerImg = panelBlocker.AddComponent<Image>();
        blockerImg.color = new Color(0f, 0f, 0f, 0f);
        blockerImg.raycastTarget = true;

        Canvas blockerCanvas = panelBlocker.AddComponent<Canvas>();
        blockerCanvas.overrideSorting = true;
        blockerCanvas.sortingOrder = 199;
        panelBlocker.AddComponent<GraphicRaycaster>();

        RectTransform blockerRT = panelBlocker.GetComponent<RectTransform>();
        blockerRT.anchorMin = Vector2.zero;
        blockerRT.anchorMax = Vector2.one;
        blockerRT.offsetMin = Vector2.zero;
        blockerRT.offsetMax = Vector2.zero;

        panelBlocker.SetActive(false);
        jukeboxPanel.SetActive(false);
    }

    public void Open()
    {
        IsOpen = true;
        jukeboxPanel.SetActive(true);
        panelBlocker?.SetActive(true);
    }

    public void Close()
    {
        IsOpen = false;
        jukeboxPanel.SetActive(false);
        panelBlocker?.SetActive(false);
    }

    void Update()
    {
        if (!IsOpen) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
            return;
        }

        Vector2 mousePos = Input.mousePosition;

        // Begin drag
        if (Input.GetMouseButtonDown(0))
        {
            if (!needlePlaced && RectTransformUtility.RectangleContainsScreenPoint(needle, mousePos, uiCamera))
            {
                dragging = needle;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(needle, mousePos, uiCamera, out Vector2 local);
                dragOffset = needle.anchoredPosition - local;
            }
            else if (!chipPlaced && RectTransformUtility.RectangleContainsScreenPoint(computerChip, mousePos, uiCamera))
            {
                dragging = computerChip;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(computerChip, mousePos, uiCamera, out Vector2 local);
                dragOffset = computerChip.anchoredPosition - local;
            }
        }

        // Drag
        if (Input.GetMouseButton(0) && dragging != null)
        {
            RectTransform parent = dragging.parent as RectTransform;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, mousePos, uiCamera, out Vector2 localPoint))
                dragging.anchoredPosition = localPoint + dragOffset;
        }

        // Release
        if (Input.GetMouseButtonUp(0) && dragging != null)
        {
            if (dragging == needle)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(needleDropZone, mousePos, uiCamera))
                {
                    needle.anchoredPosition = needleDropZone.anchoredPosition;
                    needlePlaced = true;
                }
                else
                {
                    needle.anchoredPosition = needleStartPos;
                }
            }
            else if (dragging == computerChip)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(chipDropZone, mousePos, uiCamera))
                {
                    computerChip.anchoredPosition = chipDropZone.anchoredPosition;
                    chipPlaced = true;
                }
                else
                {
                    computerChip.anchoredPosition = chipStartPos;
                }
            }

            dragging = null;

            if (needlePlaced && chipPlaced && !IsDone)
                OnPuzzleComplete();
        }
    }

    void OnPuzzleComplete()
    {
        IsDone = true;

        if (audioSource != null && successSound != null)
            audioSource.PlayOneShot(successSound);

        Invoke(nameof(LoadWinScreen), 1.0f);
    }

    void LoadWinScreen()
    {
        SceneManager.LoadScene(winSceneName);
    }
}
