using UnityEngine;

public class PhoneArrows : MonoBehaviour
{
    public GameObject nextPage;
    public GameObject lastPage;
    //public bool HasClicked = false;

    

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject highlighted;

    void Start()
    {
       
    }

    void OnMouseDown()
    {
        nextPage.SetActive(true);
        lastPage.SetActive(false);
        highlighted.SetActive(false);
        arrow1.SetActive(false);
        arrow2.SetActive(true);

        //if (MapManager.IsOpen) return;
        //if (PinCodeMiniGame.IsOpen) return;

        //HasClicked = true;
        // Toggle the menu on click
       
    }

    void Awake()
    {
      
    }

    void OnMouseEnter()
    {
        {
            highlighted.SetActive(true);
        }

    }

    void OnMouseExit()
    {
        highlighted.SetActive(false);
    }
}
