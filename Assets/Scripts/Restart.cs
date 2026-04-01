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
}
