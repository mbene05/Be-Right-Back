using UnityEngine;
using System.Collections;
public class TileRotateManager : MonoBehaviour
{
   public TileRotate[] tiles;
    public GameObject chef;
    public bool isSolved = false;
    private AudioSource audioSource;
    public AudioClip winSound;
    public bool playSfx = false;

  
    public GameObject authenticatedOverlay;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


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
        if (playSfx == false)
        {
            audioSource.PlayOneShot(winSound);
            playSfx = true;
        }
        if (isSolved) return;
        ChefManager selectedChef = chef.GetComponent<ChefManager>();
        selectedChef.logsCollected++;
        isSolved = true;
        StartCoroutine(ShowAuthenticated());
        Debug.Log("PUZZLE SOLVED!");
    }

    IEnumerator ShowAuthenticated()
    {
        if (authenticatedOverlay != null)
            authenticatedOverlay.SetActive(true);
        yield return new WaitForSeconds(4f);
        if (authenticatedOverlay != null)
            authenticatedOverlay.SetActive(false);
    }
}
