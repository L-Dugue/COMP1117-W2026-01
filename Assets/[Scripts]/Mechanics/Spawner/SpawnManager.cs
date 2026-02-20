using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EntitySpawner spawner;

    public Gem gemPrefab;
    public Cherry cherryPrefab;

    // Two actions
    public void OnSpawnCherry(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Cherry cherry = spawner.Spawn(cherryPrefab, GetRandomPosition());
            cherry.DoCherryStuff();
        }
    }

    public void OnSpawnGem(InputAction.CallbackContext context) 
    {
        if (context.started)
        {
            Gem gem = spawner.Spawn(gemPrefab, GetRandomPosition());
            gem.DoGemStuff();
        }
    }

    public Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-5, 5), Random.Range(-2, 2), 0);
    }
}