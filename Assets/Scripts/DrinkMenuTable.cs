using UnityEngine;
using UnityEngine.EventSystems;

public class DrinkMenuTable : MonoBehaviour
{
    public GameObject menuPanel;
    public DialogueManager dialogueManager;
    public bool HasClicked = false;
    public bool HasClickedFR = false;

    private SpriteRenderer sr;
    private int openTimer = 0;

    public GameObject highlighted;
    public AudioClip paperRustle;

    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Make sure menu is hidden at start
        menuPanel.SetActive(false);
    }
    void Update()
    {
        if (menuPanel.activeSelf && Input.GetMouseButtonDown(0) && openTimer > 5)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                menuPanel.SetActive(false);
                openTimer = 0;
            }
        }
        if (menuPanel.activeSelf)
            openTimer++;
    }

    void OnMouseDown()
    {
        if (dialogueManager.dialogueStarted) return;
        highlighted.SetActive(false);

        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;

        HasClicked = true;
        HasClickedFR = true;
        openTimer = 0;
        Debug.Log("Menu object activated");
        // Toggle the menu on click
        menuPanel.SetActive(true);
        audioSource.PlayOneShot(paperRustle);
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        if (menuPanel.activeInHierarchy)
        {
            highlighted.SetActive(false);
        }
        else
        {
            highlighted.SetActive(true);
        }
           
    }

    void OnMouseExit()
    {
        highlighted.SetActive(false);
    }
}
