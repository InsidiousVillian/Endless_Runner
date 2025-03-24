using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SectionTrigger : MonoBehaviour
{
    public GameObject runningSection;
    public float sectionLength = 30f; // Length of each section
    public int sectionsToKeep = 2;
    private bool hasTrigger = false;

    int obstacleCount;


    //reference to obj spawner script
    public RandomObjectSpawner randomObjectSpawner;
   
    //used to store sections in a list
    private static List<GameObject> activeSections = new List<GameObject>();
    
  private void OnTriggerEnter(Collider other)
{
    // Check if the player enters the section trigger (with the tag "Trigger")
    if (other.gameObject.CompareTag("Player") && !hasTrigger)
    {
        Debug.Log("Player has entered the section trigger");

        // Calculate spawn position for the new section
        Vector3 spawnPosition = transform.position + Vector3.forward * sectionLength;
        spawnPosition.x = 1; // Keep X as 1 (adjust if necessary)
        spawnPosition.y = 0; // Keep Y as 0 (adjust if necessary)

        Debug.Log("Calculated spawn position: " + spawnPosition);

        // Instantiate the new section at the calculated position
        if (runningSection != null)
        {
            GameObject newSection = Instantiate(runningSection, spawnPosition, Quaternion.identity);
            activeSections.Add(newSection);

            // Remove the oldest section if more than the allowed number of sections are active
            if (activeSections.Count > sectionsToKeep)
            {
                GameObject oldestSection = activeSections[0];
                activeSections.RemoveAt(0);
                Destroy(oldestSection);
                Debug.Log("Oldest section destroyed. Active sections count: " + activeSections.Count);
            }
            else
            {
                Debug.Log("New section spawned successfully. Active sections count: " + activeSections.Count);
            }
        }
        else
        {
            Debug.LogError("Running Section Prefab is not assigned in the inspector!");
        }

        // Spawn obstacles if RandomObjectSpawner is assigned
        if (randomObjectSpawner != null)
        {
            obstacleCount = Random.Range(4, 4); // Adjust range as needed
            Debug.Log("Spawning " + obstacleCount + " obstacles");

            for (int i = 0; i < obstacleCount; i++)
            {
                randomObjectSpawner.SpawnObject(spawnPosition, sectionLength);
            }
        }
        else
        {
            Debug.LogError("RandomObjectSpawner is not assigned in the inspector!");
        }

        // Set hasTrigger to true to prevent spawning the section multiple times
        hasTrigger = true;
    }
    else
    {
        // Log other collisions if necessary
        Debug.Log("Non-player object entered trigger: " + other.gameObject.name + " with tag: " + other.gameObject.tag);
    }
}



   
    private void OnTriggerExit(Collider other)
    {
        // Resets the trigger when the other object exits
        if (other.gameObject.CompareTag("trigger"))
        {
            ResetTrigger();
        }
    }
   
    public void ResetTrigger()
    {
        hasTrigger = false;
    }
    
    /*destroys all active sections and clears tracking list*/
    public static void ClearAllSections(){
        //goes through each section stored in list
        foreach(GameObject section in activeSections){
            //checks if section ref is still valid before destorying - prevents errors
            if(section != null){
                //destroys section
                Destroy(section);
            }
        }
        activeSections.Clear();
    }
}