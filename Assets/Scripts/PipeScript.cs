using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour
{
    public float[] correctRotations;
    public bool isCorrect = false;
    public bool isPartOfSolution = true;

    [Range(0, 360)]
public float currentRotation;

    PipePuzzleManager puzzleManager;

    bool isRotating = false;

    SpriteRenderer sr;

    void Start()
    {
        puzzleManager = FindObjectOfType<PipePuzzleManager>();
        sr = GetComponent<SpriteRenderer>();
        float[] rotations = { 0, 90, 180, 270 };
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        CheckRotation();
    }


    void Update()
    {
        currentRotation = transform.eulerAngles.z;
    }

    private void OnMouseDown()
    {
        if (MapManager.IsOpen) return;
        if (!isRotating)
            StartCoroutine(RotateSmooth());
    }

    IEnumerator RotateSmooth()
    {
        isRotating = true;

        float duration = 0.1f;
        float time = 0f;

        Quaternion startRot = transform.rotation;
        Quaternion endRot = startRot * Quaternion.Euler(0, 0, 90);

        while (time < duration)
        {
            transform.rotation = Quaternion.Slerp(startRot, endRot, time / duration);
            time += Time.deltaTime;
            yield return null;
        }


        float snappedZ = Mathf.Round(transform.eulerAngles.z / 90f) * 90f;
        transform.eulerAngles = new Vector3(0, 0, snappedZ);

        isRotating = false;

        CheckRotation();
        puzzleManager.CheckWin();
    }

   void CheckRotation()
    {
        float currentZ = transform.eulerAngles.z;
        isCorrect = false;

        foreach (float rotation in correctRotations)
        {
            if (Mathf.Abs(Mathf.DeltaAngle(currentZ, rotation)) < 1f)
            {
                isCorrect = true;
                break;
            }
        }
    }

 public void TurnGreen()
    {
        if (isPartOfSolution)
            StartCoroutine(GreenTransition());
    }

    IEnumerator GreenTransition()
    {
        float duration = 1f;
        float time = 0f;

        Color startColor = sr.color;
        Color targetColor = Color.green;

        while (time < duration)
        {
            sr.color = Color.Lerp(startColor, targetColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        sr.color = targetColor;
    }
}