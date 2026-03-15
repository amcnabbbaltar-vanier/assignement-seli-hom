using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevelGoal1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = GameManager.Instance.GetTotalScore(); //Current score should be at lest 4
        //so we need to add to 4 to get to 8 for the next level
        Debug.Log("Current Score: " + currentScore);
        if (currentScore >= 12)
        {
            Debug.Log("Score: " + GameManager.Instance.GetTotalScore());
            //starTimer += Time.deltaTime;

            SceneManager.LoadScene("ThirdLevel");

        }
    }
}
