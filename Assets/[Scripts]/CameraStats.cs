using UnityEngine;

public class CameraStats
{
    private float smoothTime;

    public float SmoothTime
    {
        get
        {
            return smoothTime;
        }
        set
        {
            if(value > 10)
            {
                smoothTime = 10;
            }
            else
            {
                smoothTime = value;
            }
        }
    }
}
