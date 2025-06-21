using System.Data.Common;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float bulletZDepth = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is working");

            Vector3 screenPosition = Input.mousePosition;

            // Convert screen position to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(
                screenPosition.x, 
                screenPosition.y, 
                bulletZDepth // This should be the distance from the camera to where you want the bullet
            ));

            Debug.Log($"World click position: {worldPosition}");

            // Instantiate bullet at world position
            Instantiate(bulletPrefab, worldPosition, Quaternion.identity);
        }   
    }
}
