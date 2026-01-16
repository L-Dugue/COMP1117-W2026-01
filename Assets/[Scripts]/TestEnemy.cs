using UnityEngine;
using UnityEngine.InputSystem;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            player.TakeDamage(10);
        }
    }
}

