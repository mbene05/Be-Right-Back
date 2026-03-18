using UnityEngine;

public class TileRotateManager : MonoBehaviour
{
   public TileRotate[] tiles;
    public GameObject chef;
    public bool isSolved = false;


    void Update()
    {
        if (isSolved) return;

        foreach (TileRotate tile in tiles)
        {
            if (!tile.IsCorrect)
                return;
        }

        PuzzleSolved();
    }

    void PuzzleSolved()
    {
        if (isSolved) return;
        ChefManager selectedChef = chef.GetComponent<ChefManager>();
        selectedChef.logsCollected++;
        isSolved = true;
        Debug.Log("PUZZLE SOLVED!");
    }
}
