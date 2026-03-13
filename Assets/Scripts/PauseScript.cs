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
        pauseMenuPanel.SetActive(true);

        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);

        Time.timeScale = 1.0f;

        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        //DontDestroyOnLoad(GameManager.Instance);
        GameManager.Instance.scoreText.text = "Score: 0";
        DontDestroyOnLoad(pauseMenuPanel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        //Application.Quit();

        SceneManager.LoadScene("MainMenuScene");
    }
}
