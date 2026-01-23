using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    public void AdjustHealthBar(bool playerIsDead, int playerHealth)
    {
        if (healthBar.gameObject.activeSelf)
        {
            if (playerIsDead)
            {
                return;
            }
            else
            {
                healthBar.value = playerHealth;
            }
            
        }
       
    }

    public void AdjustHealthBarDeath()
    {
        if (!healthBar.gameObject.activeSelf)
        {
            return;
        }
        else
        {
            healthBar.value = 0;
            healthBar.gameObject.SetActive(false);
        }
    }
}
