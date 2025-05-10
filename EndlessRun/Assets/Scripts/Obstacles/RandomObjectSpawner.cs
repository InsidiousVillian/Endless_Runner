using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// 
/// 
/// 
/// 
///spawns a random object from list at random pos 
/// ensures obj isnt too close to previously spawned ones
/// keeps only limited numberv of obj alive at time - destroys oldest
/// each spawned obj set to 2 sec before destroying. - can be increased
///
/// 
/// 
/// 
/// 
///  </summary>

public class RandomObjectSpawner : MonoBehaviour
{
    //array of obj we can spown (all of oue obstacle gamobjects add here)
    public GameObject[] myObjects;

    // defines how far from start point object should be placed
    public float minDistanceFromStart = 5f; 
    public float maxDistanceFromStart = 15f; 

    //  width of which obj can appear 
    public float minXPosition = -3f;
    public float maxXPosition = 3f; 


    //keeps track of spawned obstacles
    private List<GameObject> spawnedObjectsList = new List<GameObject>();
    //max number of obj allowed at a time
    public int objectsToKeep = 4;


    private void Start()
    {
        // only works if in unity editor 
        #if UNITY_EDITOR
        // Debug check for objects
        if (myObjects == null || myObjects.Length == 0)
        {
            Debug.LogError("NO OBJECTS CONFIGURED IN RANDOM OBJECT SPAWNER!");
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
        #endif
    }

    //method spawns obstacle using sectionStartPos variable and the section Length
   //
   public GameObject SpawnObject(Vector3 sectionStartPosition, float sectionLength)
    {
        
        // checks if myobjects have been assigned or not in insepctor - will only run when in UnityEditor
        if (myObjects == null || myObjects.Length == 0)
        {
            #if UNITY_EDITOR
            Debug.LogError("No objects available to spawn!");
            return null;
            #endif
        }
        

    // Minimum distance between each obstacles, this value can be tweaked 
        float minSpawnDistance = 2f; 
    // Maximum attempts to find a valid spawn position
        int maxAttempts = 10;

        //loops 10 times to find valid spawn points
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            // Chooses a random obstacle between 0 and our array length
            int randomIndex = Random.Range(0, myObjects.Length);
            //assigns random object picked to selected prefab variable under type Gameobject so we can spawn obj
            GameObject selectedPrefab = myObjects[randomIndex];
       
            // Randomise the spawn distance along the Z-axis, but ensure it's spread out - done to avoid obstacles dont spawn dont go beyond section length
            float distanceZ = Random.Range(minDistanceFromStart, Mathf.Min(maxDistanceFromStart, sectionLength - 5f));
       
            // Randomise X position within the defined range
            float distanceX = Random.Range(minXPosition, maxXPosition);
       
            // Calculate the spawn position relative to section start
            Vector3 spawnPosition = sectionStartPosition + new Vector3(distanceX, 0, distanceZ);
       
            // Ensures Y position is set to 0 (donq so obstacles odnt spawn mid air)
            spawnPosition.y = 0f;


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
                //will spawn the randomly chosen obstacle - in the chosen spawn position and we stop the rotation so that obj doesnt spawn rotated 
                GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            
                // Destroy the object after 2 seconds - this is hardcoded but can be changed later on 
                Destroy(spawnedObject, 2f);
            
                AddSpawnedObject(spawnedObject);
                return spawnedObject;
            }
        }
        // If we couldn't find a valid spawn position after max attempts
        Debug.LogWarning("Could not find a valid spawn position for obstacle");
        return null;
    } 


    // prevents overspawning of obstacles - helps with spawn spacing 
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
        

        // Add the new object to the list
        spawnedObjectsList.Add(spawnedObject);

        Debug.Log($"After adding object. Final count: {spawnedObjectsList.Count}");
    }
}