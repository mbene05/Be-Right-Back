using NUnit.Framework.Constraints;
using UnityEngine;

public class JukeboxManager : MonoBehaviour
{
   
    public DialogueManager dialogueManager;
     private SpriteRenderer sr;

    public Color hoverColor = Color.red;
    private Color originalColor;

    public TextAsset myInkJSON; 


    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (PinCodeMiniGame.IsOpen) return;

        dialogueManager.StartDialogue(myInkJSON,null);
    
        
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
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
