using UnityEngine;

public class ChefCoslog : MonoBehaviour
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
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;
        if (DialogueManager.choicesActive) return;

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
