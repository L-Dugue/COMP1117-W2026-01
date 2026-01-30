using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

[RequireComponent(typeof(Rigidbody2D))]

public class Character : MonoBehaviour
{
    // Private Variables
    [Header("Character Stats Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private bool isDead = false;
    private int currentHealth;
    protected Rigidbody2D rigidBody;
    protected Animator anim;
    protected SpriteRenderer sprite;

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
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();

        // stats = new PlayerStats(moveSpeed, maxHealth, initialBoostMultiplier, initialBoostTimer);
    }

    public virtual void TakeDamage(int amount)
    {
        Debug.Log(currentHealth);
        // Level Of Protection
        if (IsDead)
        {
            Die();
            return;
        }
        if(currentHealth <= 0)
        {
            Die();
        }

        // ACTUAL LOGIC
        CurrentHealth -= amount;
    }

    protected virtual void Die()
    {
        if (isDead)
        {
           return; 
        } 
        else if(currentHealth <= 0)
        {
            isDead = true;
        }
        
    }

    

    
}
