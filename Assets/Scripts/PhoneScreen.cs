using UnityEngine;

public class PhoneScreen : MonoBehaviour
{
    
    public Camera cam;
    
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject page1;
    public GameObject page2;
    public int timer;
    public GameObject phone;
    void Start()
    {
        timer = 0;
        arrow1.SetActive(true);
        page1.SetActive(true);
       
    }

    void Update()
{   
    timer++;
    if (Input.GetMouseButtonDown(0) && !RoomSwitcher.IsTransitioning)
    {
        

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            if (timer >= 10)
            {
                if (hit.collider.gameObject == gameObject)
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
        phone.GetComponent<PhoneScript>().HasClicked = false;
        Debug.Log("NO work");
        timer = 0;
        arrow1.SetActive(false);
        page1.SetActive(false);
        arrow2.SetActive(false);
        page2.SetActive(false);
    }
}
