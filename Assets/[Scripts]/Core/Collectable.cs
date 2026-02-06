using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Collectable : MonoBehaviour
{
    void Awake()
    {
        if( GetComponent<CircleCollider2D>().isTrigger != true)
        {
            GetComponent<CircleCollider2D>().isTrigger = true; // Sets the trigger to true.
        }
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        Debug.Log("Item Picked Up!");
        Destroy(gameObject);
    }
    
}
