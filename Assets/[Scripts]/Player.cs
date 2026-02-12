using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

[RequireComponent(typeof(HealthBarHandler))]
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(AnimationHandler))]

public class Player : Character
{
    [Header("Player Stats")]
    [SerializeField] private float jumpForce = 12f; // The force of the jump
    [SerializeField] private LayerMask groundLayer; // Checks to see if I am standing on the ground Layer
    [SerializeField] private Transform groundCheck; // Position of my ground check
    [SerializeField] private float groundCheckRadius = 0.2f; // Size of my ground check radius circle

    [Header("Boost Properties")]
    [SerializeField] private float boostMultiplier;
    [SerializeField] private float boostTime;

    


    // Private variables
    private HealthBarHandler healthBarHandler;
    private InputHandler input;
    private AnimationHandler animHandler;
    private bool isGrounded;
    private bool isBoostTimerCoroutineActive = false;
    private bool isBoosting = false;
    private float currentSpeedModifier = 1f;

    // Public Variables
    public bool IsBoosting
    {
        get{return isBoosting; }
        private set{isBoosting = value; }
    }

    protected override void Awake()
    {   
        base.Awake();
        input = GetComponent<InputHandler>();
        healthBarHandler = GetComponent<HealthBarHandler>();
        //animHandler = GetComponent<AnimationHandler>();
    }

    void Update()
    {
        // Perform my ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

         // Set movement animation values
        anim.SetFloat("XVelocity", Mathf.Abs(rigidBody.linearVelocity.x));

        // Set jumping animation values
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("YVelocity", rigidBody.linearVelocity.y);

        // Flips the character if they are moving Right or Left
        if(input.MoveInput.x != 0 && !IsDead)
        {
            transform.localScale = new Vector3(Mathf.Sign(input.MoveInput.x), transform.localScale.y, 1);
        }
        
    }

    void FixedUpdate()
    {
        if (IsDead)
        {
            return;
        }

        // Handle Movewment
        HandleMovement();
        // Handle Jumping
        HandleJump();

        if(transform.localScale.y != 1)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        }
        
    }

    private void HandleMovement()
    {
        if (!IsBoosting)
        {
            float horizontalVelocity = input.MoveInput.x * MoveSpeed * currentSpeedModifier;
            rigidBody.linearVelocity = new Vector2(horizontalVelocity, rigidBody.linearVelocity.y);

            currentSpeedModifier = 1f;
        }
        else
        {
            ApplyBoost();
        }
        
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

        //ApplyJumpAnimation(horizontalVelocity);
        
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        healthBarHandler.AdjustHealthBar(IsDead, CurrentHealth);
        
        
    }

    public override void Die()
    {
        healthBarHandler.AdjustHealthBarDeath();
        isDead = true;
        rigidBody.linearVelocity = Vector2.zero;
    }

    public void EnableBoost()
    {
        IsBoosting = true;
    }

    private void ApplyBoost()
    {
        if (!isBoostTimerCoroutineActive)
        {
            StopAllCoroutines();
            StartCoroutine(boostTimer());
        }
        
        float horizontalVelocity = input.MoveInput.x * MoveSpeed;
        rigidBody.linearVelocity = new Vector2(horizontalVelocity * boostMultiplier, rigidBody.linearVelocity.y);
        Debug.Log(MoveSpeed * boostMultiplier);
    }

    private IEnumerator boostTimer()
    {
        isBoostTimerCoroutineActive = true;
        yield return new WaitForSeconds(boostTime);
        IsBoosting = false;
        isBoostTimerCoroutineActive = false;

    }

    public void ApplySpeedModifier(float speedModifier)
    {
        currentSpeedModifier = speedModifier;
    }

    public void FlipPlayerVertically()
    {
        gameObject.transform.localScale = new Vector3( gameObject.transform.localScale.x,  -1,  gameObject.transform.localScale.z);
    }

}
