using UnityEngine;


public class skipbutton : MonoBehaviour
{
    public TilePuzzleManager puzzleManager;

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        puzzleManager.SkipDialogue();
    }
}