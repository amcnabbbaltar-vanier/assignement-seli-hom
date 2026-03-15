using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement movement;
    private Rigidbody rb;
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
        animator.SetFloat("PlayerSpeed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", movement.SetIsGrounded());

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (movement.SetIsGrounded())
                animator.SetTrigger("doFlip");
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
}
