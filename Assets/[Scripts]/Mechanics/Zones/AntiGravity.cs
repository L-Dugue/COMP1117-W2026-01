using UnityEngine;

public class AntiGravity : Zone
{
    // Private field holding the Player.cs script
    private Player _player; 

    protected override void ApplyZoneEffect(Player player)
    {
        // If null, assign the variable
        if(_player == null)
        {
            _player = player;
        }
        
        // Flips the player and inverts gravity scale.
        _player.FlipPlayerVertically();
        _player.GetComponent<Rigidbody2D>().gravityScale = -1f;
        Debug.Log("Player entered Anti-Gravity Zone");
    }

    // Reverts the gravityScale to normal once the player has left the AntiGravityZone
    void OnTriggerExit2D(Collider2D collision)
    {
        _player.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Debug.Log("Player exited Anti-Gravity Zone");
    }
}
