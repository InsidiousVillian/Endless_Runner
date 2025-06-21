using System.Data.Common;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;
    public AudioClip Shooting;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlaySound(Shooting);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 direction;

            // Check if ray hits something
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                direction = (hit.point - shootPoint.position).normalized;
            }
            else
            {
                // If nothing hit, use ray direction
                direction = ray.direction.normalized;
            }

            // Instantiate bullet
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            // Set bullet direction
            bullet.GetComponent<BulletLevel2>().Initialize(direction * bulletSpeed);
        }
    }
}
