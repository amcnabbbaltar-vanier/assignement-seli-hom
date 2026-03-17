using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrapScript : MonoBehaviour
{
    public bool movingRight = true;
    public float moveSpeed = 2f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Vector3 direction = movingRight ? Vector3.right : Vector3.left;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("Collided with wall, changing direction");
            movingRight = !movingRight;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            //Debug.Log("Entered wall trigger, changing direction");
            movingRight = !movingRight;
        }
    }
}
