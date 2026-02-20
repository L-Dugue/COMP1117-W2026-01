using UnityEngine;

public class Gem : Collectable
{   
    [SerializeField] private SpriteRenderer spriteRend;
    protected override void OnCollect()
    {
        base.OnCollect();
        Debug.Log("Ooh, very shiny! This gem would be great in my collection!");
        
    }

    public void DoGemStuff()
    {
        Debug.Log("<color=cyan> SPARKLE SPARKLE SPARKLE </color>");
        spriteRend.color = Color.cyan;
    }
}
