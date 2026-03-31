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
    public static string endSceneName = "DeathScreen"; 
    public float percent;
    public float currentTime;

    private bool hasEnded = false;
    private bool isTimerRunning = false;



    void Start()
    {
        bar.fillAmount = 1f;
        currentTime = maxTime;
        
        percent = currentTime / maxTime;

        StartCoroutine(StartTimerDelay()); //start delay

    }

    void Update()
    {
        //DONT FORET TO TAKE OUT LATER
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentTime = 0;
        }

        percent = currentTime / maxTime;
        UpdateBarColor();

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

    }

    IEnumerator StartTimerDelay()
    {
        yield return new WaitForSeconds(60f); //delay of 60 seconds before the timer starts
        isTimerRunning = true;
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        if (currentTime > maxTime)
            currentTime = maxTime;

        UpdateBarColor();

        bar.fillAmount = currentTime / maxTime;
        Debug.Log("Bar increased by " + amount + " Current: " + currentTime);
    }

    public void ReduceTime(float amount)
    {
        currentTime -= amount;
        if (currentTime < 0)
            currentTime = 0;

        UpdateBarColor();

        bar.fillAmount = currentTime / maxTime;
        Debug.Log("Bar reduced by " + amount + " Current: " + currentTime);
    }

    
    public static void LoadEndScene()
    {
        Debug.Log("Time's up! Loading end scene...");
        PlayerPrefs.SetInt("SkipIntro", 1);
        SceneManager.LoadScene(endSceneName);
    }

    void UpdateBarColor()
    {
        

        if (percent <= 0.2f)
        {
            bar.color = Color.red;
        }
        else if (percent <= 0.5f)
        {
            bar.color = Color.yellow;
        }
        else
        {
            bar.color = Color.green; // optional default
        }
    }
    

}