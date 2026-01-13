using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    TagCollection tagCollection = new TagCollection();

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(tagCollection.PlayerTag))
        {
            if (collider.gameObject.GetComponent<PlayerController>().stats.isBoosting)
            {
                return;
            }
            else
            {
                collider.gameObject.GetComponent<PlayerController>().EnableBoost();
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}
