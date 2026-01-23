using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class Character : MonoBehaviour
{
    // Private Variables
    [Header("Character Stats Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Slider healthBar;

    // public PlayerStats stats;

    private int currentHealth;
    private bool isDead = false;

    // Public properties
    public float MoveSpeed
    {
        // Read-Only
        get { return moveSpeed; }
    }
    
    protected int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    public bool IsDead
    {
        get{ return isDead; }
    }


    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        // stats = new PlayerStats(moveSpeed, maxHealth, initialBoostMultiplier, initialBoostTimer);
    }

    public void TakeDamage(int amount)
    {
        // Level Of Protection
        if (IsDead)
        {
            return;
        }

        // ACTUAL LOGIC
        CurrentHealth -= amount;
    }

    protected void Die()
    {
        
    }
}
