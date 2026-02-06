using UnityEngine;

public class DeathZone : Zone
{
    protected override void ApplyZoneEffect(Player player)
    {
        player.Die();
        Debug.Log("Player entered deathZone");
    }
}
