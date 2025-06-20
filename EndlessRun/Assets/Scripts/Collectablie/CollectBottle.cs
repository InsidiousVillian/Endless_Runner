using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectBottle : MonoBehaviour
{

    public AudioClip PickupBottle;
    void OnTriggerEnter(Collider other) {
        if  (other.CompareTag("Player")) {
            Debug.Log("Bottles is collected. Current count : " + (MasterInfo.bottleCount + 1));
            MasterInfo.bottleCount += 1;
            AudioManager.Instance.PlaySound(PickupBottle);
            Destroy(gameObject);
        }
    }   
}