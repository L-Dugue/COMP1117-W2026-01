using UnityEngine;

public class AntiGravity : Zone
{
    private Player _player;
    protected override void ApplyZoneEffect(Player player)
    {
        if(_player == null)
        {
            _player = player;
        }
       
        _player.FlipPlayerVertically();
        _player.GetComponent<Rigidbody2D>().gravityScale = -1f;
        Debug.Log("Player entered Anti-Gravity Zone");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        _player.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Debug.Log("Player exited Anti-Gravity Zone");
    }
}
