using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PasswordPuzzle : MonoBehaviour
{
    public static PasswordPuzzle Instance { get; private set; }
    public static bool IsOpen { get; private set; }

    [Header("Panel")]
    public GameObject puzzlePanel;

    [Header("Password")]
    public string correctPassword = "1234";
    public bool maskInput = true; // show **** instead of typed chars

    [Header("Display")]
    public TextMeshProUGUI displayText;

    [Header("Buttons")]
    public Button[] digitButtons; // assign 0–9 in order in the Inspector
    public Button clearButton;
    public Button submitButton;

    [Header("Feedback Overlays")]
    public GameObject promptOverlay; // "Enter the code"
    public GameObject failOverlay;   // "Wrong code!"
    public GameObject winOverlay;    // "Access granted!"

    [Header("On Success")]
    public UnityEvent onSuccess;

    private enum State { Idle, Entering, Failed, Won }
    private State state;

    private string inputBuffer = "";
    private float failTimer;
    private const float FailDuration = 1.2f;

    void Awake() => Instance = this;

    void Start()
    {
        for (int i = 0; i < digitButtons.Length; i++)
        {
            int digit = i;
            if (digitButtons[i] != null)
                digitButtons[i].onClick.AddListener(() => AppendChar(digit.ToString()));
        }

        if (clearButton  != null) clearButton.onClick.AddListener(ClearInput);
        if (submitButton != null) submitButton.onClick.AddListener(Submit);

        puzzlePanel.SetActive(false);
    }

    public void Open()
    {
        IsOpen = true;
        inputBuffer = "";
        puzzlePanel.SetActive(true);
        SetState(State.Idle);
    }

    public void Close()
    {
        IsOpen = false;
        puzzlePanel.SetActive(false);
    }

    void Update()
    {
        if (!IsOpen) return;

        if (Input.GetKeyDown(KeyCode.Escape)) { Close(); return; }

        if (state == State.Failed)
        {
            failTimer -= Time.deltaTime;
            if (failTimer <= 0f) SetState(State.Idle);
            return;
        }

        if (state == State.Won)
        {
            if (Input.GetMouseButtonDown(0)) Close();
            return;
        }

        // Keyboard typing support
        foreach (char c in Input.inputString)
        {
            if (char.IsLetterOrDigit(c))
                AppendChar(c.ToString().ToUpper());
            else if (c == '\b')
                RemoveLastChar();
            else if (c == '\n' || c == '\r')
                Submit();
        }
    }

    void AppendChar(string c)
    {
        if (state == State.Won || state == State.Failed) return;
        inputBuffer += c;
        SetState(State.Entering);
        UpdateDisplay();
    }

    void RemoveLastChar()
    {
        if (inputBuffer.Length == 0) return;
        inputBuffer = inputBuffer[..^1];
        UpdateDisplay();
        if (inputBuffer.Length == 0) SetState(State.Idle);
    }

    void ClearInput()
    {
        if (state == State.Won) return;
        inputBuffer = "";
        SetState(State.Idle);
        UpdateDisplay();
    }

    void Submit()
    {
        if (state == State.Won || state == State.Failed) return;

        if (inputBuffer == correctPassword)
        {
            SetState(State.Won);
            onSuccess?.Invoke();
        }
        else
        {
            inputBuffer = "";
            SetState(State.Failed);
        }
    }

    void UpdateDisplay()
    {
        if (displayText == null) return;
        displayText.text = maskInput
            ? new string('*', inputBuffer.Length)
            : inputBuffer;
    }

    void SetState(State newState)
    {
        state = newState;

        promptOverlay?.SetActive(newState == State.Idle);
        failOverlay?.SetActive(newState == State.Failed);
        winOverlay?.SetActive(newState == State.Won);

        if (newState == State.Idle || newState == State.Entering)
            UpdateDisplay();

        if (newState == State.Failed)
        {
            failTimer = FailDuration;
            UpdateDisplay();
        }
    }
}
