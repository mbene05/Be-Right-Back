using UnityEngine;

public class DrinkMenuScreen : MonoBehaviour
{
    public int timer;
    void Update()
    {
        timer++;
        if (Input.GetMouseButtonDown(0) && timer > 20)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
}

