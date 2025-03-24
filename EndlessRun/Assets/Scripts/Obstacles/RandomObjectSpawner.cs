using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;

    public float minDistanceFromStart = 5f; // Minimum distance from start of section
    public float maxDistanceFromStart = 15f; // Maximum distance from start of section
    public float minXPosition = -3f; // Minimum X position range
    public float maxXPosition = 3f; // Maximum X position range

    // Method to spawn objects on a specific section and return the object
    public GameObject SpawnObject(Vector3 sectionStartPosition, float sectionLength)
    {
        // Chooses a random obstacle
        int randomIndex = Random.Range(0, myObjects.Length);

        // Randomize the spawn distance along the Z-axis, but ensure it's spread out
        float distanceZ = Random.Range(minDistanceFromStart, Mathf.Min(maxDistanceFromStart, sectionLength - 5f));

        // Randomize X position within the defined range
        float distanceX = Random.Range(minXPosition, maxXPosition);

        // Calculate the spawn position relative to section start
        Vector3 spawnPosition = sectionStartPosition + new Vector3(distanceX, 0, distanceZ);

        // Ensure Y position is set to 0 (or whatever height you want for ground level)
        spawnPosition.y = 0f; // This will prevent obstacles from spawning at unexpected heights

        // Instantiate the object
        GameObject spawnedObject = Instantiate(myObjects[randomIndex], spawnPosition, Quaternion.identity);
       
        return spawnedObject;
    }
}

