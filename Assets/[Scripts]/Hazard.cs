using UnityEngine;

public class Hazard : MonoBehaviour
{   
    // Private fields, instances of needed Objects
    TagCollection tagCollection = new TagCollection();
    HazardStats hazardStats = new HazardStats(25);

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Takes damage once the Player has entered the Trigger
        if (collision.CompareTag(tagCollection.PlayerTag))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(hazardStats.DamageAmount);
        }
    }
}
