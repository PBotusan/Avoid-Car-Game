using UnityEngine;

public class ActivateChunk : MonoBehaviour
{
    [SerializeField] LevelGeneration spawnLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spawnLevel.SpawnTriggerEntered();
        }
    }
}
