using UnityEngine;

public class BulletLevel2 : MonoBehaviour
{
     private Vector3 moveDirection;
    public float bulletSpeed = 100f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = moveDirection * bulletSpeed;
        }
        else
        {
            Debug.LogError("No Rigidbody found on Bullet prefab.");
        }

        Destroy(gameObject, 2f);
    }

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
