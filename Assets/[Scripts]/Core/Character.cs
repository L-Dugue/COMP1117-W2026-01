using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour
{
    // Private Variables
    [Header("Character Stats Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth = 100;
    protected bool isDead = false;
    private int currentHealth;
     
    protected Rigidbody2D rigidBody;
    protected Animator anim;

    // Public properties
    public float MoveSpeed
    {
        // Read-Only
        get { return moveSpeed; }
        set { moveSpeed = math.clamp(value, 0, 100);}
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

    // public float BoostMultiplier
    // {
    //     get
    //     {
    //         return boostMultiplier;
    //     }

    //     set
    //     {
    //         if(value > 5)
    //         {
    //             boostMultiplier = 5;
    //         }
    //         else
    //         {
    //             boostMultiplier = value;
    //         }
    //     }
    // }

    // protected float BoostTime
    // {
    //     get
    //     {
    //         return boostTime;
    //     }

    //     set
    //     {
    //         if(value > 5)
    //         {
    //             boostTime = 5;
    //         }
    //         else
    //         {
    //             boostTime = value;
    //         }
    //     }
    // }


    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        //stats = new PlayerStats(moveSpeed, maxHealth, initialBoostMultiplier, initialBoostTimer);
    }

    public virtual void TakeDamage(int amount)
    {
        Debug.Log(currentHealth);
        // Level Of Protection
        if (IsDead)
        {
            return;
        }
        if(currentHealth <= 0)
        {
            Die();
        }

        // ACTUAL LOGIC
        CurrentHealth -= amount;
    }

    public abstract void Die();
}
