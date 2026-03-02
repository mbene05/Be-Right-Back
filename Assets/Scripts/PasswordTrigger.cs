using UnityEngine;

public class PasswordTrigger : MonoBehaviour
{
    void OnMouseDown()
    {
        if (MapManager.IsOpen)      return;
        if (MazeMiniGame.IsOpen)    return;
        PasswordPuzzle.Instance.Open();
    }
}
