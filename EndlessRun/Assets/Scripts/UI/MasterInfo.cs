using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    [SerializeField] GameObject bottleDisplay;
    public static int bottleCount = 0;
    
    // Update is called once per frame
    void Update()
    {
        bottleDisplay.GetComponent<TMPro.TMP_Text>().text = "Bottles:" + bottleCount;
    }
}
