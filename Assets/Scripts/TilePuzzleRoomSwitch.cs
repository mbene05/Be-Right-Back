using UnityEngine;

public class TilePuzzleRoomSwitch : MonoBehaviour
{
    public void MoveTo(Transform newTarget)
    {
        transform.position = newTarget.position;
        transform.rotation = newTarget.rotation;
    }
}