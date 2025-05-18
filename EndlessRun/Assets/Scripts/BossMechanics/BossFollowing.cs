using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossFollowing : MonoBehaviour
{
    public List<Transform> spawnpoints;
    public GameObject enemyPrefab;
    public float spawnTimer = 0f;
    public float spawnInterval = 5f;
    public bool canSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canSpawn) return;
        spawnTimer += Time.fixedDeltaTime;
        if (spawnTimer >= spawnInterval) 
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
        
    }

    void SpawnEnemy()
    {
        if(spawnpoints.Count == 0) return;
        
        Transform spawnPoint = spawnpoints[Random.Range(0, spawnpoints.Count)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.localRotation);
        Debug.Log($"Enemy spawned at {spawnPoint.position}");
    }
}
