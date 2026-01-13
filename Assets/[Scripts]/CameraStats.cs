using System;
using UnityEngine;

public class CameraStats
{

    private float smoothTime;
    private GameObject trackedObj;
    private Vector3 offset;
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
    public GameObject TrackedObj
    {
        get
        {
            return trackedObj;
        }
        set
        {
            if (value is GameObject)
            {
                trackedObj = value;
            }
            else
            {
                Debug.LogError("Assigned variable TrackedObj a non GameObject type. Assign a value of type GameObject");
            }
        }
    }
    public Vector3 cameraVelocity = new Vector3(0, 0, 10);
    public Vector3 targetPos
    {
        get
        {
            return trackedObj.transform.position - CameraOffset;
        }
        private set
        {
            // CAN NOT BE
        }
    }
    public Vector3 CameraOffset
    {
        get
        {
            return offset;
        }
        set
        {
            if (value.x > 25 || value.y > 25 || value.z > 25) 
            {
                offset = new Vector3(25, 25, 25);
                Debug.LogWarning("Can not make offset greater than the vec3 (25, 25, 25), defaulting to: (25, 25, 25)");
            }
            else
            {
                offset = value;
            }
        }
    }

    public CameraStats(float _smoothTime, GameObject _trackingObj)
    {
        smoothTime = _smoothTime;
        trackedObj = _trackingObj;
    }
}
