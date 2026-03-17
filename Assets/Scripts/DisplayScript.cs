using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
    [Header("UI References")]
    public Text scoreText;
    public Text healthText;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.StartTimer();
        UpdateScore();
        UpdateLives();
    }

    // Update is called once per frame
    void Update()
    {
        float timer = GameManager.Instance.GetTime();
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

        UpdateScore();
        UpdateLives();
    }

    public void UpdateScore()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.GetTotalScore();
        }
    }

    public void UpdateLives()
    {
        //int livesLeft = GameManager.Instance.TotalLivesLeft();
        if (healthText != null)
        {
            healthText.text = "Health: " + 
               GameManager.Instance.TotalLivesLeft();
        }
    }
}
