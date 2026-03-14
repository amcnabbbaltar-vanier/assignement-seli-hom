using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StarComponent : MonoBehaviour
{
    private float starTimer = 0f;
    private float starInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.IncrementScore();
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //starTimer += Time.deltaTime;

        //if(starTimer >= starInterval)
        //{
        //    if (gameObject.activeSelf)
        //    {
        //        gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        gameObject.SetActive(false);
        //    }
        //    starTimer = 0f;
        //}
    }
}
