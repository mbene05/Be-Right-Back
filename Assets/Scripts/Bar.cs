using UnityEngine;
using UnityEngine.UI;

using Ink.Runtime;

using UnityEngine.SceneManagement;

public class Bar : MonoBehaviour
{
    public Image bar;
    public float maxTime;
    public string endSceneName = "DeathScreen"; 
    
    private float currentTime;

    private bool hasEnded = false;
   

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
        else if (!hasEnded)
        {
            hasEnded = true;
            LoadEndScene();
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

    
    void LoadEndScene()
    {
        Debug.Log("Time's up! Loading end scene...");
        SceneManager.LoadScene(endSceneName);
    }
    
    // Optional: Refill the bar
   // public void RefillTime()
   // {
    //    currentTime = maxTime;
    //   bar.fillAmount = 1f;
    //}

}