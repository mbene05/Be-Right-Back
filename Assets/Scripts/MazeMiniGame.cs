using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MazeMiniGame : MonoBehaviour
{
    public static MazeMiniGame Instance { get; private set; }
    public static bool IsOpen { get; private set; }
    bool done = false;

    public GameObject tileTrigger;
    [Header("Panel")]
    public GameObject mazePanel;
    public RectTransform mazeBounds; // the outer boundary

    [Header("Zones")]
    public RectTransform startZone;
    public RectTransform exitZone;
    public GameObject chef;
    public bool done2 = false;

    [Header("Draggable Object")]
    public RectTransform draggableObject; // The object the player drags through the maze

    [Header("Walls")]
    public RectTransform[] walls;

    [Header("Feedback")]
    public GameObject instructionOverlay; // "Click and drag the object to the exit"
    public GameObject failOverlay;        // "You touched the wall!"
    public GameObject winOverlay;         // "You made it!"

    private enum State { Idle, Dragging, Failed, Won }
    private State state;

    private float failTimer;
    private const float FailDuration = 0.8f;

    private float winGraceTimer;
    private const float WinGraceDuration = 1.0f;

    private Vector2 startPosition;

    private Canvas canvas;
    private Camera uiCamera;
    private GameObject mazeBlocker;

    [Header("Authenticated")]
    public GameObject authenticatedOverlay;

    [Header("Audio")]
    private AudioSource audioSource;
    public AudioClip winSound;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canvas = mazePanel.GetComponentInParent<Canvas>();
        uiCamera = canvas ? canvas.worldCamera : null;

        // Force panel to render over everything
        Canvas panelCanvas = mazePanel.GetComponent<Canvas>();
        if (panelCanvas == null) panelCanvas = mazePanel.AddComponent<Canvas>();
        panelCanvas.overrideSorting = true;
        panelCanvas.sortingOrder = 200;
        if (mazePanel.GetComponent<GraphicRaycaster>() == null)
            mazePanel.AddComponent<GraphicRaycaster>();

        // Full-screen blocker so nothing behind can be clicked
        mazeBlocker = new GameObject("MazeBlocker");
        mazeBlocker.transform.SetParent(mazePanel.transform.parent, false);

        Image blockerImg = mazeBlocker.AddComponent<Image>();
        blockerImg.color = new Color(0f, 0f, 0f, 0f);
        blockerImg.raycastTarget = true;

        Canvas blockerCanvas = mazeBlocker.AddComponent<Canvas>();
        blockerCanvas.overrideSorting = true;
        blockerCanvas.sortingOrder = 199;
        mazeBlocker.AddComponent<GraphicRaycaster>();

        RectTransform blockerRT = mazeBlocker.GetComponent<RectTransform>();
        blockerRT.anchorMin = Vector2.zero;
        blockerRT.anchorMax = Vector2.one;
        blockerRT.offsetMin = Vector2.zero;
        blockerRT.offsetMax = Vector2.zero;

        mazeBlocker.SetActive(false);
        mazePanel.SetActive(false);

        if (draggableObject != null)
            startPosition = draggableObject.anchoredPosition;
    }

    public void Open()
    {
        IsOpen = true;
        mazePanel.SetActive(true);
        mazeBlocker?.SetActive(true);
        ResetDraggable();
        SetState(State.Idle);
    }

    public void Close()
    {
        IsOpen = false;
        mazePanel.SetActive(false);
        mazeBlocker?.SetActive(false);
    }

    void ResetDraggable()
    {
        if (draggableObject != null)
            draggableObject.anchoredPosition = startPosition;
    }

    // Returns true if any corner of the draggable is inside the given rect
    bool DraggableTouchesRect(RectTransform rect)
    {
        Vector3[] corners = new Vector3[4];
        draggableObject.GetWorldCorners(corners);
        foreach (Vector3 corner in corners)
        {
            Vector2 screenCorner = RectTransformUtility.WorldToScreenPoint(uiCamera, corner);
            if (RectTransformUtility.RectangleContainsScreenPoint(rect, screenCorner, uiCamera))
                return true;
        }
        return false;
    }

    // Returns true if all corners of the draggable are inside the given rect
    bool DraggableInsideRect(RectTransform rect)
    {
        Vector3[] corners = new Vector3[4];
        draggableObject.GetWorldCorners(corners);
        foreach (Vector3 corner in corners)
        {
            Vector2 screenCorner = RectTransformUtility.WorldToScreenPoint(uiCamera, corner);
            if (!RectTransformUtility.RectangleContainsScreenPoint(rect, screenCorner, uiCamera))
                return false;
        }
        return true;
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

        switch (state)
        {
            case State.Idle:
                // Begin dragging when the player clicks on the draggable object
                if (Input.GetMouseButtonDown(0) && draggableObject != null)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(draggableObject, mousePos, uiCamera))
                        SetState(State.Dragging);
                }
                break;

            case State.Dragging:
                // Releasing the mouse resets the object
                if (!Input.GetMouseButton(0))
                {
                    ResetDraggable();
                    SetState(State.Idle);
                    return;
                }

                // Move the object to follow the mouse
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    draggableObject.parent as RectTransform, mousePos, uiCamera, out Vector2 localPoint))
                {
                    draggableObject.anchoredPosition = localPoint;
                }

                // Fail if any corner leaves the maze bounds
                if (!DraggableInsideRect(mazeBounds))
                {
                    SetState(State.Failed);
                    return;
                }

                // Fail if any corner touches a wall
                foreach (var wall in walls)
                {
                    if (wall == null) continue;
                    if (DraggableTouchesRect(wall))
                    {
                        SetState(State.Failed);
                        return;
                    }
                }

                // Win when the draggable reaches the exit zone
                if (DraggableTouchesRect(exitZone))
                    SetState(State.Won);
                break;

            case State.Failed:
                failTimer -= Time.deltaTime;
                if (failTimer <= 0f)
                {
                    ResetDraggable();
                    SetState(State.Idle);
                }
                break;

            case State.Won:
                audioSource.PlayOneShot(winSound);
                winGraceTimer -= Time.deltaTime;
                if (winGraceTimer <= 0f && Input.GetMouseButtonDown(0) && !MapManager.IsOpen)
                {
                    Close();
                    StartCoroutine(ShowAuthenticated());
                }
                break;
        }
    }

    IEnumerator ShowAuthenticated()
    {
        if (authenticatedOverlay != null)
            authenticatedOverlay.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (authenticatedOverlay != null)
            authenticatedOverlay.SetActive(false);
    }

    void SetState(State newState)
    {
        state = newState;

        instructionOverlay.SetActive(false);
        failOverlay.SetActive(false);
        winOverlay.SetActive(false);

        switch (newState)
        {
            case State.Idle:
                instructionOverlay.SetActive(true);
                break;
            case State.Dragging:
                break;
            case State.Failed:
                failOverlay.SetActive(true);
                failTimer = FailDuration;
                break;
            case State.Won:
                winOverlay.SetActive(true);
                winGraceTimer = WinGraceDuration;
                if (done2 == false)
                {
                    ChefManager selectedChef = chef.GetComponent<ChefManager>();
                    selectedChef.logsCollected++;
                    done2 = true;
                }
                break;
        }
    }
}
