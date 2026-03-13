using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstLevelGoal : MonoBehaviour
{
    private float starTimer = 0f;
    private float starInterval = 2.5f;
    public GameObject star;
    private int targetScore = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        starTimer += Time.deltaTime;

        if (starTimer >= starInterval)
        {
            if (star.activeSelf)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
            starTimer = 0f;
        }
    }
}
