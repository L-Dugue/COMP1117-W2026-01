using UnityEngine;

public struct TagCollection
{
    

    // Properties
    public string PlayerTag
    {
        get
        {
          return "Player";  
        }

        private set
        {
            // Private set, can not be used.
        }
    }
    
    public string SpeedBoostTag
    {
        get
        {
            return "SpeedBoost";
        }
        private set
        {
            // Private set, can not be used.
        }
    }
}
