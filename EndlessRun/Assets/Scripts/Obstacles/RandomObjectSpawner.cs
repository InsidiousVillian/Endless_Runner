using UnityEngine;
using System.Collections.Generic;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    
    public float minDistanceFromStart = 5f; // Minimum distance from start of section
    public float maxDistanceFromStart = 15f; // Maximum distance from start of section
    public float minSpacingBetweenObjects = 3f; // Minimum spacing between spawned objects
    public float minXPosition = -3f; // Minimum X position range
    public float maxXPosition = 3f; // Maximum X position range

    private List<Vector3> usedPositions = new List<Vector3>(); // To store used positions and avoid overlaps
    
    // Method to spawn objects on a specific section
    public void SpawnObject(Vector3 sectionStartPosition, float sectionLength)
    {
        // Chooses a random obstacle
        int randomIndex = Random.Range(0, myObjects.Length);
        
        // Randomises the spawn distance along the Z-axis, but ensures its spread out
        float distanceZ = Random.Range(minDistanceFromStart, Mathf.Min(maxDistanceFromStart, sectionLength - 5f));
        
        // Randomise X position within the defined range
        float distanceX = Random.Range(minXPosition, maxXPosition);
        
        // Calculate the spawn position relative to section start
        Vector3 spawnPosition = sectionStartPosition + new Vector3(distanceX, 0, distanceZ);

        spawnPosition.y = 0f; // This will prevent obstacles from spawning at unexpected heights

        // Ensure we don't spawn objects too close to each other
        bool tooClose = true;
        int attempts = 0;
        while (tooClose && attempts < 10)
        {
            tooClose = false;
            
            // Check if the position is too close to any already used position
            foreach (Vector3 usedPosition in usedPositions)
            {
                if (Vector3.Distance(usedPosition, spawnPosition) < minSpacingBetweenObjects)
                {
                    tooClose = true;
                    break;
                }
            }
            
            // If the position is too close, try a new random position
            if (tooClose)
            {
                distanceZ = Random.Range(minDistanceFromStart, Mathf.Min(maxDistanceFromStart, sectionLength - 5f));
                distanceX = Random.Range(minXPosition, maxXPosition);
                spawnPosition = sectionStartPosition + new Vector3(distanceX, 0, distanceZ);
                spawnPosition.y = 0f; // Ensure Y is reset to 0
                attempts++;
            }
        }
        
        usedPositions.Add(spawnPosition);
        
        //creates the random obj at the location
        Instantiate(myObjects[randomIndex], spawnPosition, Quaternion.identity);
    }
}
