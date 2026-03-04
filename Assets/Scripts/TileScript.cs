using UnityEngine;

public class TileScript : MonoBehaviour
{

    public Vector3 targetPosition;
    public Vector3 correctPosition;
    public int number;
    public bool inrightPlace = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        correctPosition = transform.position;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetPosition == correctPosition)
        {
            inrightPlace = true;
        }

        else
        {
            inrightPlace = false;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
    }
}
