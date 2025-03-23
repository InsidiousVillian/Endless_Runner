using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SectionTrigger : MonoBehaviour
{
    public GameObject runningSection;
    public float sectionLength = 30f; // Length of each section
    public int sectionsToKeep = 1;
    private bool hasTrigger = false;
   
    //used to store sections in a list
    private static List<GameObject> activeSections = new List<GameObject>();
    
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
            GameObject newSection = Instantiate(runningSection, spawnPosition, Quaternion.identity);
            activeSections.Add(newSection);
            if(activeSections.Count > sectionsToKeep){
                GameObject oldestSection = activeSections[0];
                activeSections.RemoveAt(0);
                Destroy(oldestSection);
            }
           
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