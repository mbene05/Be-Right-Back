using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{
    // Update is called once per frame


   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(RestartRoutine());
        }
    }

    IEnumerator RestartRoutine()
    {
        //thedate.saidOp = false;
        JukeboxPanelManager.ResetStatics();
        DateManager.ResetStatics();
        PlayerPrefs.DeleteAll();

        yield return null; 

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void restart()
    {
        JukeboxPanelManager.ResetStatics();
        DateManager.ResetStatics();
        MazeMiniGame.ResetStatics();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("SkipIntro", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MainScene");
    }
}
