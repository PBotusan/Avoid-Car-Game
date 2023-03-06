using UnityEngine;

public class ActivateChunk : MonoBehaviour
{
    [SerializeField] LevelGeneration spawnLevel;

    private void Start()
    {
        GameObject levelGenerationAsGameobject = GameObject.FindGameObjectWithTag("LevelGeneration");
        spawnLevel = levelGenerationAsGameobject.GetComponent<LevelGeneration>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spawnLevel.SpawnTriggerEntered();
        }
    }
}
