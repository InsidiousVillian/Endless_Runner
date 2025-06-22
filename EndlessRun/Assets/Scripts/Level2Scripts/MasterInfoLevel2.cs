using System.ComponentModel.Design;
using UnityEngine;

public class MasterInfoLevel2 : MonoBehaviour
{
    [SerializeField] GameObject bottleDisplay;

    public static int BottleCount = 0;

    private void Start()
    {
        Debug.Log("[Gamemanager level 2 working]");
    }

    void Update()
    {
        if (bottleDisplay)
        {
            Debug.Log("bottleDisplay is Active");
            bottleDisplay.GetComponent<TMPro.TMP_Text>().text = "Bottles:" + BottleCount;
        }
    }
}
