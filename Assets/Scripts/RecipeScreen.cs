using UnityEngine;

public class RecipeScreen : MonoBehaviour
{
    
    public int timer;
    void Update()
    {
        timer++;
        if (Input.GetMouseButtonDown(0) && timer > 20 && !MapManager.IsOpen)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
}
