using UnityEngine;
using System.Collections;

public class PipePuzzleManager : MonoBehaviour
{
    PipeScript[] pipes;
    bool puzzleSolved = false;
    public GameObject chef;

    public GameObject SinkClogged;
    public GameObject SinkFull;
    private AudioSource audioSource;
    public AudioClip winSound;
    public bool won = false;
    public GameObject authenticatedOverlay;
    public Camera mainCamera;
    public float cameraZPosition = -10f;
    public GameObject tilereturnRoom;

    public GameObject Arrow;
    public GameObject Arrow2;
    public GameObject Back;

    



    public GameObject tileTrigger;
    public Sprite room_coatcheck_fg_pipe_fixed;

    private HotbarManager hotbar;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pipes = FindObjectsOfType<PipeScript>();
        hotbar = FindObjectOfType<HotbarManager>();
    }

    public void CheckWin()
    {
        if (puzzleSolved)
            return;

        foreach (PipeScript pipe in pipes)
        {
            if (!pipe.isPartOfSolution)
                continue;

            if (!pipe.isCorrect)
                return;
        }

        puzzleSolved = true;
        StartCoroutine(WinSequence());
    }

    IEnumerator WinSequence()
    {
        foreach (PipeScript pipe in pipes)
        {
            pipe.TurnGreen();
        }
        Back.SetActive(false);
 
          SpriteRenderer sr = tileTrigger.GetComponent<SpriteRenderer>();
        sr.sprite = room_coatcheck_fg_pipe_fixed;
        won = true;
        audioSource.PlayOneShot(winSound);
        SinkClogged.SetActive(false);
        SinkFull.SetActive(true);
        if (authenticatedOverlay != null)
            authenticatedOverlay.SetActive(true);
        yield return new WaitForSeconds(4f);
        if (authenticatedOverlay != null)
            authenticatedOverlay.SetActive(false);
            Arrow.SetActive(true);
            Back.SetActive(true);
            Arrow2.SetActive(true);
            tileTrigger.GetComponent<PipeTrigger>().isOpen = false;
            mainCamera.transform.position = new Vector3(tilereturnRoom.transform.position.x, tilereturnRoom.transform.position.y, cameraZPosition);
    
    }
      
}