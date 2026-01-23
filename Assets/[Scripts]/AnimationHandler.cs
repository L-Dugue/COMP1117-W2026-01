using Unity.Mathematics;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{   
    [Header("Animation Variables")]
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprite;

    public void ApplyWalkAnimation(float horizontalInput)
    {
        anim.SetFloat("XVelocity", math.abs(horizontalInput));
        if(horizontalInput < 0)
        {
            sprite.flipX = true;
        }
        else if(sprite.flipX)
        {
            sprite.flipX = false;
        }
    }
}
