using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{       
    // Objects of classes
    public readonly PlayerStats stats = new PlayerStats();

    // Components
    Rigidbody2D rBody;

    // Private variables
    Vector2 moveInput;
   

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        stats.MoveSpeed = 15;
        stats.BoostMultiplier = 4;
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
        float targetVelocityX = moveInput.x * stats.MoveSpeed * stats.BoostMultiplier;
        rBody.linearVelocity = new Vector2(targetVelocityX, rBody.linearVelocity.y);
        Debug.Log(stats.MoveSpeed * stats.BoostMultiplier);
    }

    

}
