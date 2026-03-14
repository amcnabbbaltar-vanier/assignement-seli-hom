using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrapScript : MonoBehaviour
{
    public bool movingRight = true;
    private float moveSpeed = 2f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (!movingRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
          movingRight = !movingRight;
        }
    }

    private void MoveLeft()
    {
        movingRight = false;
        rb.MovePosition(rb.position + Vector3.left * moveSpeed * Time.fixedDeltaTime);

    }

    private void MoveRight()
    {
        movingRight = true;
        rb.MovePosition(rb.position + Vector3.right * moveSpeed * Time.fixedDeltaTime);

    }



}
