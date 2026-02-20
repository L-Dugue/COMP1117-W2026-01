using System.Collections.Generic;
using System.Diagnostics;

public class CircularBuffer
{
    // Collection itself
    private List<int> buffer;

    // Capacity
    private int _capacity;

    // Constructor - Allows to create a CircularBuffer with a given capacity
    public CircularBuffer(int capacity)
    {
        buffer = new List<int>(capacity);
        _capacity = capacity;
    }
    

    // Public Properties
    public int Count => buffer.Count;

    // Buffer operations

    public void Push(int item)
    {
        // Check if my buffer is at or above capacity
        if(buffer.Count >= _capacity)
        {
            buffer.RemoveAt(0); // Removes the oldest item.
        }

        buffer.Add(item); // Adds the most recent to the beginning
    }

    public int Pop()
    {
        if(buffer.Count == 0) return -1; // -1 will act as a special value to check against

        int lastIndex = buffer.Count - 1;
        int item = buffer[lastIndex]; // Grabs a copy.
        buffer.RemoveAt(lastIndex);

        return item;
    }
}
