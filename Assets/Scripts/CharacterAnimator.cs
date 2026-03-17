using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement movement;
    private Rigidbody rb;
    //public float velocityHere;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
        GameManager.Instance.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Velocity here: " + rb.velocity.magnitude);
        //velocityHere = rb.velocity.magnitude;
        animator.SetFloat("PlayerSpeed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", movement.SetIsGrounded());

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!movement.SetIsGrounded())
            {
                animator.SetTrigger("doFlip");
            }
            else
            {
                movement.maxJumpHoldTime = Time.time;
            }
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);

        }


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Star")
    //    {
    //        GameManager.Instance.IncrementScore();
    //    }
    //    if(other.gameObject.tag == "Trap")
    //    {
    //        GameManager.Instance.LoseLife();
    //    }
    //}

    //private float PleaseDebug()
    //{
    //    return velocityHere;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with an objectf!!");
        if (collision.gameObject.tag == "Wall")
        {
            GameManager.Instance.RestartThisLevel();
        }

        if(collision.gameObject.tag == "Boost")
        {
            Debug.Log("Boost found and collided");
        }
    }


}
