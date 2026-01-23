using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : Character
{       

    [Header("Animation Variables")]
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprite;



    // Objects of classes
    public PlayerStats stats;

    // Components
    private Rigidbody2D rBody;

    // Private variables
    private Vector2 moveInput;
    private bool isBoostTimerCoroutineActive = false;
    

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
       moveInput = value.Get<Vector2>();
       ApplyAnimation(); 
    }

    void FixedUpdate()
    {
        ApplyMovement();
        if (stats.IsDead)
        {
            Debug.Log("Player has perished.");
        }
    }

    
    // PUBLIC METHODS

    // Allows for the enabling of the boost, without having to do it manually.
    public bool EnableBoost()
    {
        stats.isBoosting = true;
        return stats.isBoosting;
    }

    public void TakeDamage(int damageAmount)
    {
        // If the player is dead, print to the console. Else, remove some health.
        if (stats.IsDead)
        {
            return;
        }
        else
        {
            stats.CurrentHealth -= damageAmount;
            // AdjustHealthBar();
        }
        
        
    }

    private void ApplyMovement()
    {
        if (!stats.isBoosting)
        {
            float targetVelocityX = moveInput.x * stats.MoveSpeed;
            rBody.linearVelocity = new Vector2(targetVelocityX, rBody.linearVelocity.y);
            Debug.Log(stats.MoveSpeed);
        }
        else
        {
            ApplyBoost();
        }
        
    }
    private void ApplyBoost()
    {
        if (!isBoostTimerCoroutineActive)
        {
            StopAllCoroutines();
            StartCoroutine(boostTimer());
        }
        
        float targetVelocityX = moveInput.x * stats.MoveSpeed * stats.BoostMultiplier; 
        rBody.linearVelocity = new Vector2(targetVelocityX, rBody.linearVelocity.y);
        Debug.Log(stats.MoveSpeed * stats.BoostMultiplier);
    }

    private IEnumerator boostTimer()
    {
        isBoostTimerCoroutineActive = true;
        yield return new WaitForSeconds(stats.BoostTime);
        stats.isBoosting = false;
        isBoostTimerCoroutineActive = false;

    }


    /// <summary>
    /// Helper function to adjust the HealthBar slider to the currentHealth of the player.
    /// </summary>
    // private void AdjustHealthBar()
    // {
    //     if (!stats.IsDead) // Will update the Healthbar with the currentHealth
    //     {
    //         healthBar.value = stats.CurrentHealth;
    //     }
    //     else
    //     {
    //         if (healthBar.gameObject.activeSelf)
    //         {
    //             healthBar.value = 0;
    //             healthBar.gameObject.SetActive(false);
    //         }
    //     }
    // }

    private void ApplyAnimation()
    {
        anim.SetFloat("XVelocity", math.abs(moveInput.x));
        if(moveInput.x < 0)
        {
            sprite.flipX = true;
        }
        else if(sprite.flipX)
        {
            sprite.flipX = false;
        }
    }

}
