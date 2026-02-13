using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interactions Settings")]
    [SerializeField] private float InteractRange = 1.5f;
    [SerializeField] private LayerMask interactableLayer;

    public void OnInteract(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            PerformInteraction();
        }
    }

    private void PerformInteraction()
    {
        // Find everything in a circle around the fox on the interactable layer.
        Collider2D contact = Physics2D.OverlapCircle(transform.position, InteractRange, interactableLayer);

        // Safety check
        if(contact != null)
        {
            if(contact.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InteractRange);
    }
}
