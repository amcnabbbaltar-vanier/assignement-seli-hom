using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;


    private bool isPaused = false;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        GameManager.Instance.StopTimer();
        pauseMenuPanel.SetActive(true);

        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        GameManager.Instance.ResumeTimer();
        pauseMenuPanel.SetActive(false);

        Time.timeScale = 1.0f;

        isPaused = false;
    }

    public void RestartGame()
    {
        //isPaused = false;
        Time.timeScale = 1.0f;
        //DontDestroyOnLoad(GameManager.Instance);
        // GameManager.Instance.ResetScore();
        //GameManager.Instance.ResetLives();
        GameManager.Instance.StartTimer();
        GameManager.Instance.RestartThisLevel();
       
        //DontDestroyOnLoad(pauseMenuPanel);
        //SceneManager.LoadScene("FirstLevel");
    }
    public void QuitGame()
    {
        //Application.Quit();

        SceneManager.LoadScene("MainMenuScene");
    }
}
