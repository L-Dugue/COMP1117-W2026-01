using Unity.VisualScripting;
using UnityEngine;

public class WaterZone : Zone
{
    [SerializeField] private float SpeedModifier;
    protected override void ApplyZoneEffect(Player player)
    {
        player.ApplySpeedModifier(SpeedModifier);
    }
}
