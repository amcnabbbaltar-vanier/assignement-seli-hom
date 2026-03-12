using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public Text scoreText;
    private int score = 0;
    private int targetScore = 4;


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


    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void IncrementScore()
    {
        AddScore(1);
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    public void LoadNextScene()
    {

        SceneManager.LoadScene("VictoryScene");
    }
}


