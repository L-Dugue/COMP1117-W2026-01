using UnityEngine;
using UnityEngine.InputSystem;

public class TimeRewinder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int maxFrames = 300;
    public bool isRewinding = false; // Optional visual reference to know that we are rewinding.


    private CircularBuffer intBuffer;

    private void Awake()
    {
        intBuffer = new CircularBuffer(maxFrames);
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

    private void Update()
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
        int temp = Random.Range(0, 1000);
        intBuffer.Push(temp);
        Debug.Log($"Value pushed = {temp}");
    }

    // Rewind - Rewinds on a push of a button
    private void Rewind()
    {
        int value = intBuffer.Pop();
        Debug.Log($"Value popped = {value}");
    }
}
