using UnityEngine;

public class Cherry : Collectable
{
    protected override void OnCollect()
    {
        base.OnCollect();
        Debug.Log("This cherry looks pretty delicious. I should save it for later.");
    }

    public void DoCherryStuff()
    {
        Debug.Log("<color=#b3e61cff> CHERRY CHERRY CHERRY!!! </color>");
    }
}
