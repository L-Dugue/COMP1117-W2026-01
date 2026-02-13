using UnityEngine;
using UnityEngine.Events;

public class WorldSwitch : MonoBehaviour, IInteractable
{
    [Header("World Switch Attributes")]
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private UnityEvent onActivated;
    [SerializeField] private SpriteRenderer sRend;

    private bool isFlipped = false;

    public void Interact()
    {
        isFlipped = !isFlipped; // Flips isFlipped
        sRend.sprite = isFlipped ? onSprite : offSprite; // Ternary statement... Very short If Statement

        if (isFlipped)
        {
            onActivated.Invoke();
        }
    }
    
}
