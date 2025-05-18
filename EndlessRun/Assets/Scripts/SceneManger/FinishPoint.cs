using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public MasterInfo MasterInfo;
    public  int  bottleCount = 0;
    public int maxBottleCount = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottle"))
        {
            Debug.Log("TriggerHit");
            bottleCount++;
            if (bottleCount == maxBottleCount)
            {
                Debug.Log("Scene Change");
                SceneController.instance.NextLevel();
            }
        }
        
    }
}
