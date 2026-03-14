using UnityEngine;

public class PhoneClicked : MonoBehaviour
{
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject page1;
    public GameObject page2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
    {
        arrow1.SetActive(true);
        page1.SetActive(true);
        page2.SetActive(true);
    }

    void OnDisable()
    {
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        page1.SetActive(false);
        page2.SetActive(false);
    }
}
