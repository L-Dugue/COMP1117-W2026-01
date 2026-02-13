using UnityEngine;

public class NPCLogic : MonoBehaviour, IInteractable
{
    [Header("NPC Attributes")]
   [SerializeField] private GameObject speechBubbleCanvas;

   public void Interact()
    {
        // SafetyCheck
        if(speechBubbleCanvas == null)
        {
            return;
        }

        // Gets the current state of the object, and sets the inverse.
        bool isCurrentlyActive = speechBubbleCanvas.activeSelf;
        speechBubbleCanvas.SetActive(!isCurrentlyActive);
        
    }
}
