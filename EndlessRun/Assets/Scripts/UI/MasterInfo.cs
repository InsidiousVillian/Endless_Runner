using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    [SerializeField] GameObject bottleDisplay;
    [SerializeField] GameObject gunDisplay;
    [SerializeField] GameObject highNoonDisplay;
    public static int bottleCount = 0;




    private void Start()
    {
        Debug.LogError(this.name + " HELL");


        if (bottleDisplay == null)
        {
             bottleDisplay = GameObject.Find("BottleCount");
            
        }
        if (gunDisplay == null)
        {
            gunDisplay = GameObject.Find("gunCount");
            
        }
        if (highNoonDisplay == null)
        {
            highNoonDisplay = GameObject.Find("HighNoonCount");
            
        }


        if (bottleDisplay == null || gunDisplay == null || highNoonDisplay == null)
        {
            Debug.LogWarning("One or more UI elements are missing in the scene.");
        }

        bottleCount = 0;

        if (ItemPickup.guns != null)
        {
            ItemPickup.guns.Clear();
        }
        if (HighNoonPickup.highNoonList != null)
        {
            HighNoonPickup.highNoonList.Clear();
        }
    }
    // Update is called once per frame
    void Update()
    {
         if (bottleDisplay && gunDisplay && highNoonDisplay)
        {
            bottleDisplay.GetComponent<TMPro.TMP_Text>().text = "Bottles: " + bottleCount;
            gunDisplay.GetComponent<TMPro.TMP_Text>().text = "Guns: " + ItemPickup.guns.Count;
            highNoonDisplay.GetComponent<TMPro.TMP_Text>().text = "High Noon: " + HighNoonPickup.highNoonList.Count;
        }
    }
}
