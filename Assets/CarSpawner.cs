using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] carPrefab; // the prefab of the object to spawn
    [SerializeField] PlayerController player;

    [SerializeField] float disableTime = 10f; // The amount of time after which the car gets disabled


    GameManager gameManager;

    Vector3[] carSpawnPoints = new Vector3[2];


    //best between 25 / 30 enough room between the cars
    float offset = 30;

   

    //timers
    private float spawnTimer = 0f;
    private float resetTime = 1f;

    private int currentSpawnPointIndex = 0;


    [SerializeField] private int poolSize = 5;
    private List<GameObject> carPool = new List<GameObject>();


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        carSpawnPoints[0] = new Vector3(2.3f,0,0);
        carSpawnPoints[1] = new Vector3(-2.3f, 0, 0);


        for (int i = 0; i < poolSize; i++)
        {
            int prefabIndex = i % 2;

            GameObject car = Instantiate(carPrefab[prefabIndex], Vector3.zero, Quaternion.identity);

            car.transform.rotation = Quaternion.Euler(0, 0, 180);
                        
            car.SetActive(false);
            carPool.Add(car);
        }

        spawnTimer = resetTime;
    }

    void Update()
    {
        if (gameManager.currentGameState == GameManager.GameState.LevelRunning)
        {
            SpawnObject();
        }
     
    }

    void SpawnObject()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            // Get an inactive car object from the pool
            GameObject car = GetInactiveCar();

            if (car != null)
            {
                //random value between 10 and max offset
                float randomValue = UnityEngine.Random.Range(20, offset);

                // Position the car above the player with an offset
                Vector3 spawnPosition = new Vector3(carSpawnPoints[currentSpawnPointIndex].x, player.transform.position.y + randomValue, carSpawnPoints[currentSpawnPointIndex].z);
                car.transform.position = spawnPosition;

                // Activate the car
                car.SetActive(true);

                // Toggle between spawn points
                currentSpawnPointIndex = (currentSpawnPointIndex + 1) % carSpawnPoints.Length;
            }

            spawnTimer = resetTime;
        }
    }

    // Get an inactive car object from the pool
    GameObject GetInactiveCar()
    {
        foreach (GameObject car in carPool)
        {
            if (!car.activeInHierarchy)
            {
                return car;
            }
        }

        // If there are no inactive cars in the pool, return null
        return null;
    }

}
