using UnityEngine;

public class SinkClogged : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private SpriteRenderer sr;

    public Color hoverColor = Color.red;
    private Color originalColor;

    public TextAsset myInkJSON;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
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
}
