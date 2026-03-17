using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsScript : MonoBehaviour
{
    public CharacterMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        float timer = 0f;
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.name == "SpeedBoost")
            {
                timer += Time.deltaTime;
               
                player.jumpMultiplier = 1.5f;
                if(timer >= 5f)
                {
                  timer = 0f;
                  player.jumpMultiplier = 1f;
                }
              
            }
            if(gameObject.name == "JumpBoost")
            {
                timer += Time.deltaTime;
                //while (timer < 5f)
                //{
                //    player.speedMultiplier = 1.5f;
                //}
                if (timer >= 5f)
                {
                 timer = 0f;
                 player.speedMultiplier = 1f;
                }
               
            }
            Destroy(gameObject);
        }
    }
}
