using System.Xml.Schema;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerStats
{
    // Private Backing Fields
    private float moveSpeed;
    private float boostMultiplier;
    private float boostTime;
    private float maxHealth;
    private float currentHealth;

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
    
}
