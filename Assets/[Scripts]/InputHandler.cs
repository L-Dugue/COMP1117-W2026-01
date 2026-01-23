using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Vector2 moveInput; // Left and right movement
    private bool jumpTriggered = false; // Jumping?

    // Public properties
    public Vector2 MoveInput
    {
        get { return moveInput; }
    }

    public bool JumpTriggered
    {
        get { return jumpTriggered; }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Save movmement input into moveInput field
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpTriggered = true;
        }
        else if (context.canceled)
        {
            jumpTriggered = false;
        }
    }
}
