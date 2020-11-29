using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pause : MonoBehaviour
{

    public GameObject pauseObj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESCAPE KURWAA");
            PauseGame();
        }
    }

    void PauseGame()
    {
        pauseObj.SetActive(!pauseObj.activeInHierarchy);
        if (pauseObj.activeInHierarchy == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ResumeButton()
    {
        PauseGame();
    }

    public void MenuExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}