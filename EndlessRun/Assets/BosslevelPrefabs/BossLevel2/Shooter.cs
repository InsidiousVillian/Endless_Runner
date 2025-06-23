using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile to shoot
    public Transform firePoint;         // Where the projectile spawns
    public Transform target;            // Target to shoot at (e.g., player)
    public float projectileSpeed = 10f;
    public float fireRate = 1f;

    private float fireCooldown;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (target != null && fireCooldown <= 0f)
        {
            ShootAtTarget();
            fireCooldown = 1f / fireRate;
        }
    }

    void ShootAtTarget()
    {
        Vector3 direction = (target.position - firePoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sherif"))
        {
            Debug.Log("Hit the player!");
            // Do damage here
            Destroy(gameObject);
        }
    }
}
