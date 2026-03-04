using UnityEngine;

public class TileScript : MonoBehaviour
{

    public Vector3 targetPosition;
    public Vector3 correctPosition;
    public int number;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        correctPosition = transform.position;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
    }
}
