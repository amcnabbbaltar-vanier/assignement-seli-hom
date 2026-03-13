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
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("PlayerSpeed", rb.velocity.magnitude);
        animator.SetBool("isGrounded", movement.SetIsGrounded());

        if(Input.GetKeyUp(KeyCode.Space))
        {             
            animator.SetTrigger("doFlip");
        }

    }
}
