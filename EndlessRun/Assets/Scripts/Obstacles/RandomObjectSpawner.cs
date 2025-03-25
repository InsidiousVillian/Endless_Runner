using UnityEngine;
using System.Collections.Generic;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public float minDistanceFromStart = 5f; 
    public float maxDistanceFromStart = 15f; 
    public float minXPosition = -3f;
    public float maxXPosition = 3f; 

    private List<GameObject> spawnedObjectsList = new List<GameObject>();
    public int objectsToKeep = 4;

    private void Start()
    {
        // Debug check for objects
        if (myObjects == null || myObjects.Length == 0)
        {
            Debug.LogError("NO OBJECTS CONFIGURED IN RANDOM OBJECT SPAWNER! Please add objects to the myObjects array in the inspector.");
        }
        else
        {
            Debug.Log($"Random Object Spawner initialized with {myObjects.Length} potential objects to spawn");
            
            // Print out the names of available objects
            for (int i = 0; i < myObjects.Length; i++)
            {
                Debug.Log($"Available Object {i}: {myObjects[i].name}");
            }
        }
    }

   public GameObject SpawnObject(Vector3 sectionStartPosition, float sectionLength)
{
    // checks input
    if (myObjects == null || myObjects.Length == 0)
    {
        Debug.LogError("No objects available to spawn!");
        return null;
    }

    // Minimum distance between each obstacles, this value can be tweaked 
    float minSpawnDistance = 2f; 

    // Maximum attempts to find a valid spawn position
    int maxAttempts = 10;
    for (int attempt = 0; attempt < maxAttempts; attempt++)
    {
        // Chooses a random obstacle
        int randomIndex = Random.Range(0, myObjects.Length);
        GameObject selectedPrefab = myObjects[randomIndex];
       
        // Randomise the spawn distance along the Z-axis, but ensure it's spread out
        float distanceZ = Random.Range(minDistanceFromStart, Mathf.Min(maxDistanceFromStart, sectionLength - 5f));
       
        // Randomise X position within the defined range
        float distanceX = Random.Range(minXPosition, maxXPosition);
       
        // Calculate the spawn position relative to section start
        Vector3 spawnPosition = sectionStartPosition + new Vector3(distanceX, 0, distanceZ);
       
        // Ensures Y position is set to 0
        spawnPosition.y = 0f;

        // Check distance from previously spawned objects
        bool isValidSpawn = true;
        foreach (GameObject existingObject in spawnedObjectsList)
        {
            if (existingObject != null)
            {
                float distance = Vector3.Distance(spawnPosition, existingObject.transform.position);
                if (distance < minSpawnDistance)
                {
                    isValidSpawn = false;
                    break;
                }
            }
        }

        // If spawn position is valid, spawn the object
        if (isValidSpawn)
        {
            GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            
            // Destroy the object after 2 seconds
            Destroy(spawnedObject, 2f);
            
            AddSpawnedObject(spawnedObject);
            return spawnedObject;
        }
    }

    // If we couldn't find a valid spawn position after max attempts
    Debug.LogWarning("Could not find a valid spawn position for obstacle");
    return null;
} 

    private void AddSpawnedObject(GameObject spawnedObject)
    {
        Debug.Log($"Adding spawned object. Before count: {spawnedObjectsList.Count}");

        // If we've reached the max objects, remove the oldest
        if (spawnedObjectsList.Count >= objectsToKeep)
        {
            GameObject oldestObject = spawnedObjectsList[0];
            spawnedObjectsList.RemoveAt(0);
            
            if (oldestObject != null)
            {
                Debug.Log($"Destroying oldest object: {oldestObject.name}");
                Destroy(oldestObject);
            }
        }

        // Add the new object
        spawnedObjectsList.Add(spawnedObject);

        Debug.Log($"After adding object. Final count: {spawnedObjectsList.Count}");
    }
}