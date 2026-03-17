using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float baseWalkSpeed = 5f;    // Base speed when walking
    [SerializeField] private float baseRunSpeed = 8f;     // Base speed when running
    [SerializeField] private float rotationSpeed = 10f;   // Speed at which the character rotates

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 7f;        // Jump force applied to the character
    [SerializeField] private float groundCheckDistance = 1.1f; // Distance to check for ground contact (Raycast)
    public float maxJumpHoldTime = 3f;
    public float speedMultiplier = 1.0f; // Additional multiplier for character speed ( WINK WINK )
    public float jumpMultiplier = 1.0f;
    [Header("Anim values")]
    public float groundSpeed; // Speed value used for animations

    private Rigidbody rb;              // Reference to the character's Rigidbody component
    private Transform cameraTransform; // Reference to the main camera's transform

    // Input variables
    private float moveX; // Stores horizontal movement input (A/D or Left/Right Arrow)
    //private float moveZ; // Stores vertical movement input (W/S or Up/Down Arrow)
    private bool jumpRequest; // Flag to check if the player requested a jump
    private Vector3 moveDirection; // Stores the calculated movement direction

    public bool IsGrounded => 
        Physics.Raycast(transform.position + Vector3.up * 0.01f, Vector3.down, groundCheckDistance);
  
    public bool IsRunning => Input.GetKey(KeyCode.RightShift);

    private void Awake() => InitializeComponents(); // Initialize Rigidbody and Camera reference
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        RegisterInput(); // Capture player input for movement and jumping
    }

    private void FixedUpdate()
    {
        HandleMovement(); // Handle character movement based on input
        HandleJump();  // Apply jump force if jump was requested
    }

    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the character
        rb.freezeRotation = true; // Prevent the Rigidbody from rotating due to physics interactions
        rb.interpolation = RigidbodyInterpolation.Interpolate; // Smooth physics interpolation for better movement quality

        if(Camera.main)
        {
            cameraTransform = Camera.main.transform; // Get the main camera's transform for movement direction
        }

        Cursor.lockState = CursorLockMode.Confined; // Lock the cursor to the game window
        Cursor.visible = false; // Hide the cursor for better immersion
    }


    private void RegisterInput()
    {
        moveX = Input.GetAxis("Horizontal"); // Get horizontal movement input
        //moveX = Input.GetKey(KeyCode.LeftArrow) ? -1f : Input.GetKey(KeyCode.RightArrow) ? 1f : 0f; // Get horizontal movement input
        //moveZ = Input.GetAxis("Vertical");   // Get vertical movement input no vertical input needed
        
        // Register a jump request if the player presses the Jump button
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpRequest = true;
        }
    }

    private void HandleMovement()
    {
        CalculateMoveDirection();
        HandleJump();
        RotateCharacter();
        MoveCharacter();
    }

    private void CalculateMoveDirection()
    {
        // If the camera is not assigned, move based on world space
        if (!cameraTransform)
        {
            moveDirection = new Vector3(moveX, 0).normalized;
        }
        else
        {
            // Get forward and right vectors from the camera perspective
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            // Ignore Y-axis movement to prevent unwanted tilting
            forward.y = 0f;
            right.y = 0f;

            // Normalize vectors to maintain consistent movement speed
            forward.Normalize();
            right.Normalize();

            // Calculate movement direction relative to the camera orientation
            moveDirection = (forward  + right * moveX).normalized;
        }
    }

    public bool SetIsGrounded()
    {
        return IsGrounded;
    }

    private void HandleJump()
    {
        if (jumpRequest && IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce * jumpMultiplier, ForceMode.Impulse); // Apply an instant upward force for jumping
            jumpRequest = false; // Reset the jump request flag
        }
    }

    private void RotateCharacter()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection); // Calculate the target rotation based on movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime); // Smoothly rotate towards the target direction
        }
    }

    private void MoveCharacter()
    {
        float speed = IsRunning ? baseRunSpeed : baseWalkSpeed; // Determine speed based on whether the character is running or walking

        groundSpeed = (moveDirection != Vector3.zero) ? speed : 0f; // Update ground speed for animations

        //Debug.Log("moveDirection" + moveDirection);
        //Debug.Log("movex" + moveX);
        Vector3 newVelocity = new Vector3(
            moveDirection.x * speed * speedMultiplier, 
            rb.velocity.y, // Preserve the current Y velocity to maintain gravity effects
            0
        );

        rb.velocity = newVelocity; // Set the Rigidbody's velocity to move the character


    }
}
