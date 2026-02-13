using UnityEngine;

public class TreasureChest : MonoBehaviour, IInteractable
{
    [Header("Loot Settings")]
    [SerializeField] GameObject gemPrefab;
    [SerializeField] private int gemCount = 3;
    [SerializeField] private float launchForce = 10f;

    [Header("Visuals")]
    [SerializeField] private Sprite openChestSprite;
    [SerializeField] private SpriteRenderer sRend;


    private bool isOpened = false;

    public void Interact()
    {
        if(isOpened) return;

        isOpened = true;
        OpenChest();
    }


    private void OpenChest()
    {
        // 1. Change the chest visuals.
        if(sRend != null && openChestSprite != null)
        {
            sRend.sprite = openChestSprite;
        }

        // 2. Spew gems!
        for(int i = 0; i < gemCount; i++)
        {
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
            Rigidbody2D gemRb = gem.GetComponent<Rigidbody2D>();

            if(gemRb != null)
            {
                // Create a fountain effect
                Vector2 force = new Vector2(Random.Range(-1f, 1f), 1.5f).normalized * launchForce;
                gemRb.AddForce(force, ForceMode2D.Impulse);
            }
            
        }
    }
}
