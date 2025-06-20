using UnityEngine;

public class bulletLevel2 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}