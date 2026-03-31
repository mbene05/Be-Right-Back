using UnityEngine;

public class SinkClogged : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private SpriteRenderer sr;

    public Color hoverColor = Color.red;
    public bool isUnclogSink = false;
    public bool hasClicked = false;
    private Color originalColor;

    public TextAsset myInkJSON;
    public TextAsset myInkJSON2;

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
        if (isUnclogSink == true)
        {
            if (hasClicked == true)
            {
                dialogueManager.StartDialogue(myInkJSON2, null);
            }

            if (hasClicked == false)
            {
                dialogueManager.StartDialogue(myInkJSON, null);
                hasClicked = true;
            }
        }

        else
        {
            dialogueManager.StartDialogue(myInkJSON, null);
        }
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
