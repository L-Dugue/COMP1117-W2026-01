using UnityEngine;

public class CameraController : MonoBehaviour
{   
    private TagCollection tagCollection;
    private CameraStats stats;


    void Awake()
    {
        tagCollection = new TagCollection();
        stats = new CameraStats(2, GameObject.FindWithTag(tagCollection.PlayerTag));
        stats.CameraOffset = new Vector3(0, -2, 10);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, stats.targetPos, ref stats.cameraVelocity, stats.SmoothTime);
    }
}
