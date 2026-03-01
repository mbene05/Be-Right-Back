using UnityEngine;
using UnityEngine.UI;

public class MazeMiniGame : MonoBehaviour
{
    public static MazeMiniGame Instance { get; private set; }
    public static bool IsOpen { get; private set; }

    [Header("Panel")]
    public GameObject mazePanel;
    public RectTransform mazeBounds; // the outer boundary

    [Header("Zones")]
    public RectTransform startZone;
    public RectTransform exitZone;

    [Header("Walls")]
    public RectTransform[] walls;

    [Header("Feedback")]
    public GameObject instructionOverlay; // "Hover over START to begin"
    public GameObject failOverlay;        // "You touched the wall!"
    public GameObject winOverlay;         // "You made it!"

    private enum State { Idle, Playing, Failed, Won }
    private State state;

    private float failTimer;
    private const float FailDuration = 0.8f;

    private float graceTimer;
    private const float GraceDuration = 0.3f;

    private Canvas canvas;
    private Camera uiCamera;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        canvas = mazePanel.GetComponentInParent<Canvas>();
        uiCamera = canvas ? canvas.worldCamera : null;
        mazePanel.SetActive(false);
    }

    public void Open()
    {
        IsOpen = true;
        mazePanel.SetActive(true);
        SetState(State.Idle);
    }

    public void Close()
    {
        IsOpen = false;
        mazePanel.SetActive(false);
    }

    void Update()
    {
        if (!IsOpen) return;

        // Allow closing with Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
            return;
        }

        Vector2 mousePos = Input.mousePosition;

        switch (state)
        {
            case State.Idle:
                if (RectTransformUtility.RectangleContainsScreenPoint(startZone, mousePos, uiCamera))
                    SetState(State.Playing);
                break;

            case State.Playing:
                graceTimer -= Time.deltaTime;

                bool inStartZone = RectTransformUtility.RectangleContainsScreenPoint(startZone, mousePos, uiCamera);

                if (!inStartZone && graceTimer <= 0f)
                {
                    if (!RectTransformUtility.RectangleContainsScreenPoint(mazeBounds, mousePos, uiCamera))
                    {
                        SetState(State.Failed);
                        return;
                    }

                    foreach (var wall in walls)
                    {
                        if (wall == null) continue;
                        if (RectTransformUtility.RectangleContainsScreenPoint(wall, mousePos, uiCamera))
                        {
                            SetState(State.Failed);
                            return;
                        }
                    }
                }

                if (RectTransformUtility.RectangleContainsScreenPoint(exitZone, mousePos, uiCamera))
                    SetState(State.Won);
                break;

            case State.Failed:
                failTimer -= Time.deltaTime;
                if (failTimer <= 0f)
                    SetState(State.Idle);
                break;

            case State.Won:
                if (Input.GetMouseButtonDown(0))
                    Close();
                break;
        }
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
            case State.Playing:
                graceTimer = GraceDuration;
                break;
            case State.Failed:
                failOverlay.SetActive(true);
                failTimer = FailDuration;
                break;
            case State.Won:
                winOverlay.SetActive(true);
                break;
        }
    }
}
