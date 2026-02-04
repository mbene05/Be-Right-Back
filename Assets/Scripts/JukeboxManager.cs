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
        dialogueManager.StartDialogue(myInkJSON);
    
        
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
