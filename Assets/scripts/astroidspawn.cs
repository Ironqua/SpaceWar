using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidspawn : MonoBehaviour
{
    public GameObject asteroidprefab;

    public float minx;
    public float maxx;
    public float startingy;

    public float startingSpawnInterval = 3f; 
    public float spawnIntervalDecreaseRate = 0.5f; 
    private float currentSpawnInterval;

    private void Start()
    {
        currentSpawnInterval = startingSpawnInterval;
        InvokeRepeating("spawner", 1f, currentSpawnInterval);
       

    }
    private void spawner()
    {
        float xpoint=Random.Range(minx,maxx);
        Vector3 randompos = new Vector3(xpoint, startingy, 0f);

        Instantiate(asteroidprefab, randompos, Quaternion.identity);
        currentSpawnInterval -= spawnIntervalDecreaseRate;
        if (currentSpawnInterval < spawnIntervalDecreaseRate)
        {
            currentSpawnInterval = spawnIntervalDecreaseRate;
        }
    }
}
