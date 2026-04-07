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
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public GameObject tilereturnRoom;
    public GameObject trigger;
    public GameObject Arrow;
    public GameObject Arrow2;
    public GameObject Back;


  
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
            Back.SetActive(false);
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
            Arrow.SetActive(true);
            Back.SetActive(true);
            Arrow2.SetActive(true);
            trigger.GetComponent<TilePuzzleTrigger>().isOpen = false;
            mainCamera.transform.position = new Vector3(tilereturnRoom.transform.position.x, tilereturnRoom.transform.position.y, cameraZPosition);
    
      
    
    }
}
