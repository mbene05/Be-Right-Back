using Ink.Runtime;
using System.Threading;
using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image bar;
    public float maxTime;
    public string endSceneName = "DeathScreen"; 
    
    private float currentTime;

    private bool hasEnded = false;
    private bool isTimerRunning = false;



    void Start()
    {
        bar.fillAmount = 1f;
        currentTime = maxTime;

        StartCoroutine(StartTimerDelay()); //start delay

    }

    void Update()
    {


        if (currentTime > 0 && isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            bar.fillAmount = currentTime / maxTime;
        }
        else if (currentTime <= 0 && !hasEnded)
        {
            hasEnded = true;
            LoadEndScene();
        }

        Debug.Log("Timer running: " + isTimerRunning + " | Current time: " + currentTime);
    }

    IEnumerator StartTimerDelay()
    {
        yield return new WaitForSeconds(60f);
        isTimerRunning = true;
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
    

}