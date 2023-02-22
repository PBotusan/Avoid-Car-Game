using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    EnvironmentSpawner envoirementSpawner;

    private void Start()
    {
        envoirementSpawner = GetComponent<EnvironmentSpawner>();
    }


    public void SpawnTriggerEntered()
    {
        envoirementSpawner.MoveChunkToNewPosition();
    }
}
