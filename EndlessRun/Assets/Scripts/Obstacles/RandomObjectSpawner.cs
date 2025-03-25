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
        // Validate input
        if (myObjects == null || myObjects.Length == 0)
        {
            Debug.LogError("No objects available to spawn!");
            return null;
        }

        Debug.Log($"Spawning object. Current objects in list: {spawnedObjectsList.Count}");

        // Chooses a random obstacle
        int randomIndex = Random.Range(0, myObjects.Length);
        GameObject selectedPrefab = myObjects[randomIndex];
        
        Debug.Log($"Selected object to spawn: {selectedPrefab.name}");
        
        // Randomize the spawn distance along the Z-axis, but ensure it's spread out
        float distanceZ = Random.Range(minDistanceFromStart, Mathf.Min(maxDistanceFromStart, sectionLength - 5f));
        
        // Randomize X position within the defined range
        float distanceX = Random.Range(minXPosition, maxXPosition);
        
        // Calculate the spawn position relative to section start
        Vector3 spawnPosition = sectionStartPosition + new Vector3(distanceX, 0, distanceZ);
        
        // Ensure Y position is set to 0 (or whatever height you want for ground level)
        spawnPosition.y = 0f;
        
        // Instantiate the object
        GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        
        // Add the spawned object to the list
        AddSpawnedObject(spawnedObject);
        
        return spawnedObject;
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