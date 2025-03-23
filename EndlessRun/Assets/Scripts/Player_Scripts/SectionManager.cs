using UnityEngine;
using System.Collections.Generic;

public class SectionManager : MonoBehaviour
{
    // Singleton instance
    public static SectionManager Instance { get; private set; }
    
    // List to track all sections in order of creation
    private List<GameObject> sectionList = new List<GameObject>();
    
    // Number of sections to keep (including current)
    public int sectionsToKeep = 2;
    
    private void Awake()
    {
        // Singleton pattern setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        // Initialize the list
        sectionList = new List<GameObject>();
    }
    
    // Add a section to the list when it's created
    public void AddSection(GameObject section)
    {
        sectionList.Add(section);
        
        // If we have more sections than we want to keep
        if (sectionList.Count > sectionsToKeep)
        {
            // Destroy the oldest section
            GameObject oldestSection = sectionList[0];
            sectionList.RemoveAt(0);
            Destroy(oldestSection);
        }
    }
}