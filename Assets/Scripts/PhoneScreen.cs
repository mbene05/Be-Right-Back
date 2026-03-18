using UnityEngine;

public class PhoneScreen : MonoBehaviour
{
    
    public Camera cam;
    
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject page1;
    public GameObject page2;
    public int timer;
    void Start()
    {
        timer = 0;
        arrow1.SetActive(true);
        page1.SetActive(true);
       
    }

    void Update()
{   
    timer++;
    if (Input.GetMouseButtonDown(0))
    {
        

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            if (timer >= 30)
            {
                if (hit.collider.gameObject != gameObject)
                {
                    Debug.Log("Click!!!");
                }
                else
                {
                    ClosePages();
                }
            }
        }
        else
        {
            // Clicked empty space
           // ClosePages();
        }
    }
}

void ClosePages()
{
    Debug.Log("NO work");
    timer = 0;
    arrow1.SetActive(false);
    page1.SetActive(false);
    arrow2.SetActive(false);
    page2.SetActive(false);
}
}
