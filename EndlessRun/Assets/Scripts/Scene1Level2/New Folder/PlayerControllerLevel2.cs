using Unity.Mathematics;
using UnityEngine;

public class PlayerControllerLevel2 : MonoBehaviour
{
    public float speed = 5f;
    
	[SerializeField] private GameObject bulletPrefab;
	public Transform shootPoint;
	public float bulletSpeed = 20f;
	private Vector3 direction;

	private Ray ray;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

		if (Input.GetMouseButtonDown(0))
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position,Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Aim precisely at the hit point
            Vector3 dirToHit = (hit.point - shootPoint.position).normalized;
            rb.velocity = dirToHit * bulletSpeed;
        }
        else
        {
            // No hit - shoot straight forward through mouse direction
            rb.velocity = ray.direction * bulletSpeed;
        }
    }
    }
}
