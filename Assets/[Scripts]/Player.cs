using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Player : Character
{
    [Header("Player Stats")]
    [SerializeField] private float jumpForce = 12f; // The force of the jump
    [SerializeField] private LayerMask groundLayer; // Checks to see if I am standing on the ground Layer
    [SerializeField] private Transform groundCheck; // Position of my ground check
    [SerializeField] private float groundCheckRadius = 0.2f; // Size of my ground check radius circle
    [SerializeField] private int initialBoostMultiplier = 2;
    [SerializeField] private int initialBoostTimer = 2;

    // Private variables
    private Rigidbody2D rigidBody;
    private bool isGrounded;
    private InputHandler input;

    protected override void Awake()
    {   
        base.Awake();
        rigidBody = GetComponent<Rigidbody2D>();
        input = GetComponent<InputHandler>();
    }

    void Update()
    {
        // Perform my ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void FixedUpdate()
    {
        // Handle Movewment
        HandleMovement();
        // Handle Jumping
        HandleJump();
    }

    private void HandleMovement()
    {
        float horizontalVelocity = input.MoveInput.x * MoveSpeed;
        rigidBody.linearVelocity = new Vector2(horizontalVelocity, rigidBody.linearVelocity.y);
    }
    private void HandleJump()
    {
        if(input.JumpTriggered && isGrounded)
        {
            ApplyJumpForce();
        }
    }


    private void ApplyJumpForce()
    {
        // reset vertical velocity first.
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, 0);

        // Add force
        rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        
    }

}
