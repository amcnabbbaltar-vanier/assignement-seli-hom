using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstLevelGoal : MonoBehaviour
{
    private float starTimer = 0f;
    private float starInterval = 2.5f;
    private int targetScore = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GetTotalScore() >= targetScore)
        {
            //starTimer += Time.deltaTime;
            if (starTimer >= starInterval)
            {
                SceneManager.LoadScene("SecondLevel");
            }
        }
    }
}
