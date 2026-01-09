using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{       
    // Objects of classes
    PlayerStats stats;

    // Public variables
    private float speed = 10f;

    // Components
    Rigidbody2D rBody;

    // Private variables
    Vector2 moveInput;
   

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        stats = new PlayerStats();
        stats.MoveSpeed = 20;
    }

    void OnMove(InputValue value)
    {
       moveInput = value.Get<Vector2>(); 
    }

    void FixedUpdate()
    {
        Debug.Log(stats.MoveSpeed);
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        float targetVelocityX = moveInput.x * stats.MoveSpeed;
        rBody.linearVelocity = new Vector2(targetVelocityX, rBody.linearVelocity.y);
    }
}
