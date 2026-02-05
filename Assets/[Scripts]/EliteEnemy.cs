using Unity.VisualScripting;
using UnityEngine;

public class EliteEnemy : Enemy
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    protected override void Awake()
    {

        base.Awake();
        MoveSpeed *= 2;
        EnemySizeMultiplier = 2;
        transform.localScale *= EnemySizeMultiplier;
        spriteRenderer.color = Color.gold;
    }

    protected override void Update()
    {
        base.Update();
        Debug.Log(MoveSpeed);
    }
}
