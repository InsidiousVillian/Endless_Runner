using UnityEngine;

public class BulletLevel2 : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 2f);    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
