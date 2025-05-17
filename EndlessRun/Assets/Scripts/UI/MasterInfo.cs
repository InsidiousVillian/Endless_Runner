using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    [SerializeField] GameObject bottleDisplay;
    [SerializeField] GameObject gunDisplay;
    [SerializeField] GameObject highNoonDisplay;
    public static int bottleCount = 0;


    private void Start()
    {
        Debug.LogError(this.name + "HELL");
        bottleCount = 0;

        //checking if list has be initialised
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
        if (bottleCount >= 0) 
        {
            bottleDisplay.GetComponent<TMPro.TMP_Text>().text = "Bottles:" + bottleCount;
           
            gunDisplay.GetComponent<TMPro.TMP_Text>().text = "Guns:" + ItemPickup.guns.Count;
           
            highNoonDisplay.GetComponent<TMPro.TMP_Text>().text = "High Noon:" + HighNoonPickup.highNoonList.Count;  
        }      
    }
}
