using UnityEngine;
public class SectionTrigger : MonoBehaviour
{
    public GameObject runningSection;
    public float sectionLength = 30f; // Length of each section
    private bool hasTrigger = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("trigger") && !hasTrigger)
        {
            // Finds the forward position where the next section should spawn
            Vector3 spawnPosition = transform.position + Vector3.forward * sectionLength;
            
            // Keeps the same X and y positions
            spawnPosition.x = 1;
            spawnPosition.y = 0;
            
            // Instantiate the new section at the calculated position
            Instantiate(runningSection, spawnPosition, Quaternion.identity);
            
            hasTrigger = true;
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
}