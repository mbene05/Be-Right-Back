using UnityEngine;

public class MazeTrigger : MonoBehaviour
{
    public GameObject MazeGame;
    public GameObject backButton;
    void OnMouseDown()
    {
        if (MazeGame.GetComponent<MazeMiniGame>().done2 == false)
        {
            if (MapManager.IsOpen) return;
            if (PinCodeMiniGame.IsOpen) return;
            if (RoomSwitcher.IsTransitioning) return;
            MazeMiniGame.Instance.Open();
            backButton.SetActive(true);
        }
    }
}
