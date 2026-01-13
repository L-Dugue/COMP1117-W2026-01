using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    TagCollection tagCollection = new TagCollection();

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(tagCollection.PlayerTag))
        {
            
        }
    }
}
