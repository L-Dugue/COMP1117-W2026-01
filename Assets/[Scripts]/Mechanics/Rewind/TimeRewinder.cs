using UnityEngine;
using UnityEngine.InputSystem;

public class TimeRewinder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int maxFrames = 300;
    public bool isRewinding = false; // Optional visual reference to know that we are rewinding.


    private CircularBuffer<Vector3> positionHistory;
    private CircularBuffer<Quaternion> rotationHistory;
    private CircularBuffer<Vector3> scaleHistory;

    private void Awake()
    {
        positionHistory = new CircularBuffer<Vector3>(maxFrames);
        rotationHistory = new CircularBuffer<Quaternion>(maxFrames);
        scaleHistory = new CircularBuffer<Vector3>(maxFrames);
    }

    public void OnRewind(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isRewinding = true;
            Debug.Log("Rewind started");
        }
        else if (context.canceled)
        {
            isRewinding = false;
            Debug.Log("Rewind cancelled");
        }
    }

    private void FixedUpdate()
    {
        if (!isRewinding)
        {
            Record();   
        }
        else
        {
            Rewind();
        }
        
    }

    // Record - Happens every frame
    private void Record()
    {
        positionHistory.Push(transform.position);
        rotationHistory.Push(transform.rotation);
        scaleHistory.Push(transform.localScale);

        
    }

    // Rewind - Rewinds on a push of a button
    private void Rewind()
    {
       if(positionHistory.Count > 0)
        {
            transform.position = positionHistory.Pop();
            transform.rotation = rotationHistory.Pop();

            Vector3 tempLocalScale = scaleHistory.Pop();
            transform.localScale = new Vector3(tempLocalScale.x * -1, tempLocalScale.y, tempLocalScale.z);
        }
        else
        {
            isRewinding = false;
        }
    }
}
