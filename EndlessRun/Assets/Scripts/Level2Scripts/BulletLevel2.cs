using UnityEngine;

public class BulletLevel2 : MonoBehaviour
{
     private Vector3 moveDirection;
    public float bulletSpeed = 100f;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("target"))
        {
            Debug.Log("bottle count added here");
        }
    }
}
