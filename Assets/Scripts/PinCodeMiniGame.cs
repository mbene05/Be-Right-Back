using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinCodeMiniGame : MonoBehaviour
{
    public static PinCodeMiniGame Instance { get; private set; }
    public static bool IsOpen { get; private set; }
    public GameObject BackButton;

    [Header("Panel")]
    public GameObject pinPanel;

    [Header("Code")]
    public string correctCode = "1234"; // set the 4-digit PIN here or in the inspec. --lalalalala(im going crazy) 

    [Header("Display")]
    public TextMeshProUGUI[] digitDisplays; 

    [Header("Feedback")]
    public GameObject instructionOverlay;
    public GameObject failOverlay;
    public GameObject winOverlay;

    [Header("On Success")]
    public GameObject computerChip;
    public GameObject PC;
    public Sprite pcSprite;

    private string enteredCode = "";

    private enum State { Entering, Failed, Won }
    private State state;

    private float failTimer;
    private const float FailDuration = 1.0f;
    public bool won = false;
    private float stateTimer;
    private const float StateCooldown = 0.15f;

    void Awake()
    {
        Instance = this;
        IsOpen = false;
    }

    void Start()
    {
        pinPanel.SetActive(false);
    }

    public void Open()
    {
        IsOpen = true;
        enteredCode = "";
        pinPanel.SetActive(true);
        SetState(State.Entering);
    }

    public void Close()
    {
        IsOpen = false;
        pinPanel.SetActive(false);
    }

    void Update()
    {
        if (!IsOpen) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
            return;
        }

        stateTimer -= Time.deltaTime;

        if (state == State.Failed)
        {
            failTimer -= Time.deltaTime;
            if (failTimer <= 0f)
            {
                enteredCode = "";
                SetState(State.Entering);
            }
        }

        if (state == State.Won && stateTimer <= 0f && Input.GetMouseButtonDown(0))
        {
            Close();
        }
    }

    public void OnNumberPressed(int digit)
    {
        Debug.Log($"[PinCode] Button pressed: {digit} | state: {state} | enteredCode: '{enteredCode}'");
        if (state != State.Entering) return;
        if (enteredCode.Length >= correctCode.Length) return;

        enteredCode += digit.ToString();
        RefreshDisplay();

        if (enteredCode.Length == correctCode.Length)
        {
            if (enteredCode == correctCode)
                SetState(State.Won);
            else
                SetState(State.Failed);
        }
    }

        public void OnDeletePressed()
    {
        if (state != State.Entering) return;
        if (enteredCode.Length == 0) return;

        enteredCode = enteredCode.Substring(0, enteredCode.Length - 1);
        RefreshDisplay();
    }

    void RefreshDisplay()
    {
        for (int i = 0; i < digitDisplays.Length; i++)
        {
            if (digitDisplays[i] == null) continue;
            digitDisplays[i].text = i < enteredCode.Length ? "*" : "_";
        }
    }

    void SetState(State newState)
    {
        state = newState;
        stateTimer = StateCooldown;

        instructionOverlay.SetActive(false);
        failOverlay.SetActive(false);
        winOverlay.SetActive(false);

        switch (newState)
        {
            case State.Entering:
                instructionOverlay.SetActive(true);
                RefreshDisplay();
                break;
            case State.Failed:
                failOverlay.SetActive(true);
                failTimer = FailDuration;
                break;
            case State.Won:
                winOverlay.SetActive(true);
                SpriteRenderer sr = PC.GetComponent<SpriteRenderer>();
                sr.sprite = pcSprite;
                won = true;
                BackButton.SetActive(false);
                computerChip?.SetActive(true);
                break;
        }
    }
}
