using UnityEngine;

public class PlayerStats
{
    private float moveSpeed;
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
            else
            {
               moveSpeed = value; 
            }
            
        }
    }

}
