using UnityEngine;

public class RandomHighNewSpawner : MonoBehaviour
{
    public GameObject highNoon;

    public float minDistanceFromStart = 8f;
    public float maxDistanceFromStart =18f;


    public float minXPosition = -3f;
    public float maxXPosition = 3f;


    public GameObject SpawnItem(Vector3 sectionStartPosition, float sectionLength){

        float minSpawnDistance = 3;

   
        for (int attempts = 0; attempts <= 5; attempts++){
            float distanceZ = Random.Range(minSpawnDistance, Mathf.Min(maxDistanceFromStart, sectionLength - 5f));
            float distanceX = Random.Range(minXPosition, maxXPosition);

            Vector3 spawnPosition = sectionStartPosition + new Vector3(distanceX, 0,distanceZ);

            spawnPosition.y = 1f;

            bool isValidSpawn = true;

            if(isValidSpawn){
                GameObject spawnedItem = Instantiate(highNoon, spawnPosition, Quaternion.identity);
                Destroy(spawnedItem, 5f);
                return spawnedItem;
                
            }
 
        }
        return null;
    }
}
