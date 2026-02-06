using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Zone : MonoBehaviour
{
    [Header("Zone Settings")]
    [SerializeField] private Color debugColor = new Color(0, 1, 0, 0.3f);
    private BoxCollider2D boxCollider;

    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    protected abstract void ApplyZoneEffect(Player player);

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            ApplyZoneEffect(player);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = debugColor;
        boxCollider = GetComponent<BoxCollider2D>();

        // Safety Check
        if(boxCollider != null)
        {
            Gizmos.DrawCube(transform.position + (Vector3)boxCollider.offset, boxCollider.size);

        }      
    }
}
