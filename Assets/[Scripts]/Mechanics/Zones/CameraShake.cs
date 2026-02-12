using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class CameraShake : Zone
{
    [Header("Camera Shake Attributes")]
    [SerializeField] private CinemachineImpulseSource impulseSource;

    // Overriden version of ApplyZoneEffect
    protected override void ApplyZoneEffect(Player player)
    {
        InvokeRepeating(nameof(ShakeScreen), 0f, 0.5f);
    }


    // Cancels everything once player leaves the CameraShakeZone 
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke();
        }
    }

    // Private method to cause the ScreenShake
    private void ShakeScreen()
    {
        impulseSource.GenerateImpulse();
    }
}
