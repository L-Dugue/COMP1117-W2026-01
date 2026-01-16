using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{       
    // SerializedFields
    [SerializeField] private float initialSpeed = 5.0f;
    [SerializeField] private int initialHealth = 100;


    // Objects of classes
    public readonly PlayerStats stats = new PlayerStats();

    // Components
    Rigidbody2D rBody;

    // Private variables
    Vector2 moveInput;
    bool isBoostTimerCoroutineActive = false;
    

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
       moveInput = value.Get<Vector2>(); 
    }

    void FixedUpdate()
    {
        ApplyMovement();
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
        
        float targetVelocityX = moveInput.x * (stats.MoveSpeed * stats.BoostMultiplier); 
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

    // PUBLIC METHODS

    // Allows for the enabling of the boost, without having to do it manually.
    public bool EnableBoost()
    {
        stats.isBoosting = true;
        return stats.isBoosting;
    }
}
