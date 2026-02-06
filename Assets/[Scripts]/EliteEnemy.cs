using UnityEngine;

public class EliteEnemy : Enemy
{
    [Header("Elite Enemy Attributes")]
    [SerializeField] private SpriteRenderer spriteRenderer;


    // Private fields
    private float eliteEnemyMoveSpeed;

    protected override void  Awake()
    {
        base.Awake();
        
        // Doubling Enemy Size
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 2, gameObject.transform.localScale.y * 2, gameObject.transform.localScale.z);

        // Doubles the Elite Enemy's speed
        eliteEnemyMoveSpeed = MoveSpeed * 2;

        // Gives a gold tint
        spriteRenderer.color = Color.gold;
    }

    void Update()
    {
        MoveEnemy();
        
        if(eliteEnemyMoveSpeed == MoveSpeed * 2)
        {
            return;
        }
        else
        {
            eliteEnemyMoveSpeed = MoveSpeed * 2;
        }
    }
    
}
