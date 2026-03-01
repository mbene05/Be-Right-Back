using UnityEngine;

public class MazeTrigger : MonoBehaviour
{
    void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        MazeMiniGame.Instance.Open();
    }
}
