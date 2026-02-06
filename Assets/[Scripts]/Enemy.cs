 using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy Settings")]
    [SerializeField] public float patrolDistance = 5.0f;

    private Vector2 startPos; // Starting position
    private int direction = -1; // By default, my eagle points left

    protected override void Awake()
    {

        base.Awake();
        startPos = transform.position;

    }

    private void Update()
    {
       MoveEnemy();
    }

    protected void MoveEnemy()
    {
         // Calculate the boundaries of my movement
        float leftBoundary = startPos.x - patrolDistance;
        float rightBoundary = startPos.x + patrolDistance;

        transform.Translate(Vector2.right * direction * MoveSpeed * Time.deltaTime);

        // Flip this object when it hits a boundary
        if(transform.position.x >= rightBoundary)
        {
            direction = -1; // Go left
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(transform.position.x <= leftBoundary)
        {
            direction = 1; // Go right
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }


    public override void Die()
    {
        Debug.Log("Enemy is dead");

        // Enemy death logic!
        // _________________
        // Award points / loot to the player
        // enemy death animation
        
    }
}
