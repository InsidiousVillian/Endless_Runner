using UnityEngine;

public class CollectBottleBoss : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Boss bottles collected");
        }    
    }
}
