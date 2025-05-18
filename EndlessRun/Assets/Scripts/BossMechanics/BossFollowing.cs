using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossFollowing : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float minSpawnInterval = 1f;
    [SerializeField] private float maxSpawnInterval = 3f;
    [SerializeField] private List<GameObject> spawnPoints;

    private float nextSpawnTime;

    void Start()
    {
        // Set initial spawn time
        nextSpawnTime = Time.fixedTime + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void FixedUpdate()
    {
        if (Time.fixedTime >= nextSpawnTime)
        {
            SpawnEnemy();

            // Calculate next spawn time
            nextSpawnTime = Time.fixedTime + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        // Select random enemy prefab
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Select random spawn point
        GameObject spawnPoint = spawnPoints[Random.Range(0, 9)];

        // Spawn enemy
        var go = Instantiate(enemyPrefab);
        go.SetActive(false);
        spawnPoints.Add(go);
        
    }
}
