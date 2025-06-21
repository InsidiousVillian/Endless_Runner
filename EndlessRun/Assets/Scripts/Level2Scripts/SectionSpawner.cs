using UnityEngine;
using System.Collections.Generic;

public class SectionSpawner : MonoBehaviour
{
    [Header("Section Settings")]
    public GameObject[] sectionsToSpawn; 
    public float sectionLength = 30f;    
    public int sectionsToKeep = 2;       


    // List to track active sections
    private static List<GameObject> activeSections = new List<GameObject>();

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            Debug.Log("Player entered trigger - Spawning new section in front of player");

            SpawnNewSection(other.transform); 
        }
    }

    private void SpawnNewSection(Transform playerTransform)
    {
        if (sectionsToSpawn == null || sectionsToSpawn.Length == 0)
        {
            Debug.LogError("No sections assigned to spawn!");
            return;
        }

        
        Vector3 forwardOffset = playerTransform.forward * sectionLength;
        Vector3 spawnPosition = new Vector3(
            playerTransform.position.x + forwardOffset.x,
            0f,
            playerTransform.position.z + forwardOffset.z
        );

        // Pick a random section prefab
        int index = Random.Range(0, sectionsToSpawn.Length);
        GameObject sectionPrefab = sectionsToSpawn[index];

        // Instantiate the new section
        GameObject newSection = Instantiate(sectionPrefab, spawnPosition, Quaternion.identity);
        activeSections.Add(newSection);

        // Remove the oldest section if we've exceeded the sectionsToKeep limit
        if (activeSections.Count > sectionsToKeep)
        {
            GameObject oldest = activeSections[0];
            activeSections.RemoveAt(0);
            if (oldest != null)
            {
                Destroy(oldest, 2f);
                Debug.Log("Oldest section destroyed. Active sections: " + activeSections.Count);
            }
        }
        else
        {
            Debug.Log("New section spawned. Active sections: " + activeSections.Count);
        }

    }

    public static void ClearAllSections()
    {
        foreach (GameObject section in activeSections)
        {
            if (section != null)
            {
                Destroy(section);
            }
        }
        activeSections.Clear();
    }
}


