using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;

    // Method to spawn an object at a random position
    public void SpawnObject()
    {
        int randomIndex = Random.Range(0, myObjects.Length);

        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));

        Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
    }
}