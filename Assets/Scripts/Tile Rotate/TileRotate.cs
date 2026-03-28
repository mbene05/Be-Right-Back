using UnityEngine;

public class TileRotate : MonoBehaviour
{
    public Quaternion correctRotation;
    public TileRotateManager manager;
    public bool IsCorrect = false;
    public float z = 0;

    void Awake()
    {
       
        correctRotation = transform.rotation;
    }


    void Start()
    {
       
        int randomStep = Random.Range(0, 4);
        transform.rotation = Quaternion.Euler(0, 0, randomStep * 90f);
         CheckIfCorrect();

    }

    void OnMouseDown()
    {
        if (manager.isSolved) return;
        if (RoomSwitcher.IsTransitioning) return;

         transform.Rotate(0, 0, 90);
    
        CheckIfCorrect();
    }

     void CheckIfCorrect()
    {
        // ✅ Check if Z rotation is 0
       z = Mathf.Round(transform.eulerAngles.z) % 360;

        IsCorrect = (z == 0f);
    }

    
 
}