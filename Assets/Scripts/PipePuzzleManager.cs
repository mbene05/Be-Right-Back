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



    public GameObject tileTrigger;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pipes = FindObjectsOfType<PipeScript>();
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

        yield return new WaitForSeconds(1.2f);

        DoSomethingAfterWin();
    }

    void DoSomethingAfterWin()
    {
        won = true;
        audioSource.PlayOneShot(winSound);
        SinkClogged.SetActive(false);
        SinkFull.SetActive(true);
    }
}