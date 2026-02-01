using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image bar;
    public float maxTime;
    private float currentTime;
   
    void Start()
    {
        bar.fillAmount = 1f;
        currentTime = maxTime;
    }
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            bar.fillAmount = currentTime / maxTime;
        }
    }
    //public void RefillTime()
    //{
    //    currentTime = maxTime;
    //    timeBar.fillAmount = currentTime;
    //}
}
