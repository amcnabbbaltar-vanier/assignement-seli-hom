using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Text scoreText;
    private int score = 0;
    //private int targetScore = 4;

    private float timer = 0f;
    private bool timerRunning = false;

    public Text healthText;
    private int lives = 3;


    private void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
        }
    }


    public void ResetScore()
    {
        score = 0;
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void IncrementScore()
    {
        AddScore(1);
    }

    public int  GetTotalScore()
    {
        return score;
    }
    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
        if (healthText.text != null)
        {
            healthText.text = $"Health: {lives}";
        }
    }

    public void StartTimer()
    {
               timer = 0f;
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
    public void ResumeTimer()
    {
               timerRunning = true;
    }

    public float GetTime()
    {
        return timer;
    }

    public void LoseLife()
    {
        lives -= 1;
        if (lives <= 0)
        {
            Debug.Log("Lives Finished! :(( Try Again ! :D");
            RestartThisLevel();
        }
        UpdateUI(); 
        //TotalLivesLeft();
    }

    public int TotalLivesLeft()
    {
        Debug.Log("Lives Left: " + lives);
        return lives;
    }

    public void RestartThisLevel()
    {
        lives = 3;
        ResetScore();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetTotalTime()
    {
        return timer;
    }

    public void LoadEndScene()
    {

        SceneManager.LoadScene("VictoryScene");
    }
}


