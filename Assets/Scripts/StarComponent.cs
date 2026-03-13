using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.IncrementScore();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
