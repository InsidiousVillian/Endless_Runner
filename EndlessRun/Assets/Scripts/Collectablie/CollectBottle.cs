using UnityEngine;

public class CollectBottle : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
            if (other.CompareTag("Player")){
            Debug.Log("Bottles is collected. Current count : " + (MasterInfo.bottleCount + 1));
            MasterInfo.bottleCount += 1;
            Destroy(gameObject);
        } 

    }
}
