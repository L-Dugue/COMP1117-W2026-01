using System;
using UnityEngine;

public class HazardStats
{
    // Backing Fields
    private int damageAmount;

    // Properties
    public int DamageAmount
    {
        get
        {
            return damageAmount;
        }
        set
        {
            damageAmount = Math.Clamp(value, 0, 100);
        }
    }

    // Constructor
    public HazardStats(int _damageAmount)
    {
        DamageAmount = _damageAmount;
    }
}
