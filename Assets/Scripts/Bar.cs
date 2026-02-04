using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

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

    public void AddTime(float amount)
    {
        currentTime += amount;
        if (currentTime > maxTime)
            currentTime = maxTime;

        bar.fillAmount = currentTime / maxTime;
        Debug.Log("Bar increased by " + amount + " Current: " + currentTime);
    }

    public void ReduceTime(float amount)
    {
        currentTime -= amount;
        if (currentTime < 0)
            currentTime = 0;

        bar.fillAmount = currentTime / maxTime;
        Debug.Log("Bar reduced by " + amount + " Current: " + currentTime);
    }
}