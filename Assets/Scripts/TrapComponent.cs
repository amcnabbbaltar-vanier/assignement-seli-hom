using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private float interval = 3f;
    private float levelTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.LoseLife();
            //Destroy(gameObject);
            //StartCoroutine(TrapTimer());
        }
    }

    private void Update()
    {
        StartCoroutine(TrapTimer());
    }


    private IEnumerator TrapTimer()
    {
        while (true)
        {
            levelTimer += Time.deltaTime;
            if(levelTimer >= interval)
            {
              if (gameObject.activeSelf)
                {
                    gameObject.SetActive(false);
                    levelTimer = 0f;
                }
              else
                {
                    gameObject.SetActive(true);
                    levelTimer = 0f;
                }
            }
          
        }
    }

}

