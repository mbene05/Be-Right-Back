using UnityEngine;


public class skipbutton : MonoBehaviour
{
    public TilePuzzleManager puzzleManager;

    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (RoomSwitcher.IsTransitioning) return;
        puzzleManager.SkipDialogue();
    }
}