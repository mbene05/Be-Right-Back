using UnityEngine;

public class DrinkMenuScreen : MonoBehaviour
{
    public int timer;
    public GameObject TableMenu;
    void Update()
    {
        timer++;
        if (Input.GetMouseButtonDown(0) && timer > 20 && !MapManager.IsOpen)
        {
            TableMenu.GetComponent<DrinkMenuTable>().HasClicked = false;
            gameObject.SetActive(false);
            timer = 0;
        }
    }
}

