using Unity.Mathematics;
using UnityEngine;

public class Enemy : Character
{
    // Private Values
    [Header("Enemy Settings")]
    [SerializeField] public float patrolDistance = 5.0f;
    private Vector2 startPos; // Starting position
    private int direction = -1; // By default, my eagle points left
    private float enemySizeMultiplier = 1; 
    
    // Protected Values
    protected float EnemySizeMultiplier
    {
        get{return enemySizeMultiplier;}
        set{enemySizeMultiplier = math.clamp(value, 0, 100); }
    }

    protected override void Awake()
    {
        base.Awake();

        startPos = transform.position;
    }

    protected virtual void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        // Calculate the boundaries of my movement
        float leftBoundary = startPos.x - patrolDistance;
        float rightBoundary = startPos.x + patrolDistance;

        transform.Translate(Vector2.right * direction * MoveSpeed * Time.deltaTime);

        // Flip this object when it hits a boundary
        if(transform.position.x >= rightBoundary)
        {
            direction = -1; // Go left
            transform.localScale = new Vector3(1, 1, 1) * enemySizeMultiplier;
        }
        else if(transform.position.x <= leftBoundary)
        {
            direction = 1; // Go right
            transform.localScale = new Vector3(-1, 1, 1) * enemySizeMultiplier;
        }
    }
}
