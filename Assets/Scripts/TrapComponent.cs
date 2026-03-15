using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    //[SerializeField] private GameObject trap;
    //private float interval = 3f;
    //private float levelTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TrapTimer());
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
   
    }



}

