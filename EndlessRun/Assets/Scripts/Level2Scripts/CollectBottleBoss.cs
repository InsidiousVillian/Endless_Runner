using UnityEngine;

public class CollectBottleBoss : MonoBehaviour
{
    public AudioClip bottlePickup;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Boss bottles collected");
            MasterInfo.BossBottleCount += 1;
            AudioManager.Instance.PlaySound(bottlePickup);
            Destroy(gameObject);
        }    
    }
}
