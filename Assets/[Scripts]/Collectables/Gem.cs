using UnityEngine;

public class Gem : Collectable
{
    protected override void OnCollect()
    {
        base.OnCollect();
        Debug.Log("Ooh, very shiny! This gem would be great in my collection!");
    }
}
