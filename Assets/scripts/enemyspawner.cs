using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float startingy = 5f;

    public float initialSpawnInterval = 8f;
    public float minSpawnInterval = 1f;
    public float spawnIntervalDecreaseRate = 0.1f;

    private float currentSpawnInterval;
    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        InvokeRepeating("SpawnEnemy", 3f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-3f, 3f), startingy,0f);
        Instantiate(enemyPrefab, randomPosition, Quaternion.Euler(0f,0f,-90f));
        currentSpawnInterval -= spawnIntervalDecreaseRate;
        if (currentSpawnInterval < minSpawnInterval)
        {
            currentSpawnInterval = minSpawnInterval;
        }
    }
}


