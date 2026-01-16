using System.Xml.Schema;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerStats
{
    // Private Backing Fields
    private float moveSpeed;
    private float boostMultiplier;
    private float boostTime;
    private int maxHealth;
    private int currentHealth;

    // Properties and Public Variables
    public bool isBoosting = false;

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            if(value > 20)
            {
                moveSpeed = 20;
            }
            else if(value < 0)
            {
                moveSpeed = 0;
            }
            else
            {
               moveSpeed = value; 
            }
            
        }
    }

    public float BoostMultiplier
    {
        get
        {
            return boostMultiplier;
        }

        set
        {
            if(value > 5)
            {
                boostMultiplier = 5;
            }
            else
            {
                boostMultiplier = value;
            }
        }
    }

    public float BoostTime
    {
        get
        {
            return boostTime;
        }

        set
        {
            if(value > 5)
            {
                boostTime = 5;
            }
            else
            {
                boostTime = value;
            }
        }
    }
    
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    public int CurrentHealth
    {
        get {return currentHealth;}
        set
        {
            currentHealth = Mathf.Clamp(value, 0, 100);
            Debug.Log($"Health set to : {currentHealth}");
        }
    }

    // Constructors
    public PlayerStats()
    {
        moveSpeed = 10.0f;
        maxHealth = 100;
        currentHealth = 100;
    }

    public PlayerStats(float moveSpeed, int maxHealth)
    {
        this.moveSpeed = moveSpeed;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;

        Debug.Log($"Player initalized with MoveSpeed = {moveSpeed}, MaxHealth = {maxHealth}, CurrentHealth = {currentHealth}")
    }
}
