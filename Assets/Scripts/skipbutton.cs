using UnityEngine;


public class skipbutton : MonoBehaviour
{
    public TilePuzzleManager puzzleManager;

    void OnMouseDown()
    {
        puzzleManager.SkipDialogue();
    }
}