using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    /// <summary>
    /// this script will help in the spawning of item randomly
    /// 
    /// i will first start my creating an gameobject array public
    /// 
    ///  to hold all hte items i want to spawn - this will be placed in the inspector
    /// 
    /// i will then create variables to hold how far i want them to spawn from start area
    ///  
    /// i will create a list which will hold the items spawned 
    /// 
    /// i will create a variabel to declare how many items i want spawned
    /// 
    /// 
    /// </summary>

    public GameObject[] myItems;

     public float minDistanceFromStart = 8f; 
    public float maxDistanceFromStart = 18f; 

    //  width of which obj can appear - same as obstacle spawner
    public float minXPosition = -3f;
    public float maxXPosition = 3f; 

    

    private List<GameObject> spawnedItemList = new List<GameObject>();

    public int itemToKeep = 3;

    private void Start()
    {
         // only works if in unity editor 
        #if UNITY_EDITOR
        // Debug check for objects
        if (myItems == null || myItems.Length == 0)
        {
            Debug.LogError("NO OBJECTS CONFIGURED IN RANDOM OBJECT SPAWNER!");
        }
        else
        {
            Debug.Log($"Random Object Spawner initialized with {myItems.Length} potential objects to spawn");
            
            // Print out the names of available objects
            for (int i = 0; i < myItems.Length; i++)
            {
                Debug.Log($"Available Object {i}: {myItems[i].name}");
            }
        }
        #endif
        
    }

    public GameObject SpawnItem(Vector3 sectionStartPosition, float sectionLength ){
        // checks if myobjects have been assigned or not in insepctor - will only run when in UnityEditor
        if (myItems == null || myItems.Length == 0)
        {
            #if UNITY_EDITOR
            Debug.LogError("No objects available to spawn!");
            return null;
            #endif
        }

        float minSpawnDistance = 3;

        int MaxAttempts = 5; 

        for (int attempts = 0; attempts < MaxAttempts; attempts++){
            int randomIndex = Random.Range(0, myItems.Length);

            GameObject selectedItem = myItems[randomIndex];

            float distanceZ = Random.Range(minSpawnDistance, Mathf.Min(maxDistanceFromStart, sectionLength - 5f));

            float distanceX = Random.Range(minXPosition, maxXPosition);

       
            Vector3 spawnPosition = sectionStartPosition + new Vector3(distanceX, 0, distanceZ);

            spawnPosition.y = 1f;

            bool isValidSpawn = true;
            foreach (GameObject exisitingItem in spawnedItemList) {
                if(exisitingItem != null){
                    float distance = Vector3.Distance(spawnPosition, exisitingItem.transform.position);
                    if(distance < minSpawnDistance){
                        isValidSpawn = false;
                        break;
                    }
                }
            }
        

            if(isValidSpawn){
                GameObject spawnedItem = Instantiate(selectedItem, spawnPosition , Quaternion.identity);

                Destroy(spawnedItem, 5f);

                AddSpawnedItem(spawnedItem);

                return spawnedItem;

            }  
        }
        return null;
    }
        
        
        private void AddSpawnedItem(GameObject spawnItem){
            // If we've reached the max objects, remove the oldest
            if (spawnedItemList.Count >= itemToKeep)
            {
            GameObject oldestItem = spawnedItemList[0];
            spawnedItemList.RemoveAt(0);
            
            if (oldestItem != null)
            {
                Debug.Log($"Destroying oldest object: {oldestItem.name}");
                Destroy(oldestItem);
            }
        }  
        spawnedItemList.Add(spawnItem);   
    }
}
