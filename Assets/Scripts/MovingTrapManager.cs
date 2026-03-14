using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrapManager : MonoBehaviour
{
    public GameObject[] movingTraps;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        for(int i = 0; i < movingTraps.Length; i++)
        {
            if (timer >= 4f)
            {
              
               movingTraps[i].SetActive(true);
                timer = 0f;

            }
        }

    }

    

}
