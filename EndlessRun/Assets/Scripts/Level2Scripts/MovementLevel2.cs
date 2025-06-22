using System.Runtime.InteropServices;
using UnityEngine;

public class MovementLevel2 : MonoBehaviour
{
    public float speed = 5f;
    public AudioClip DeathSound;
    void Update()
    {
        // Move player to the right
        transform.position += Vector3.right * speed * Time.deltaTime;

    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player is dead");
        transform.position = transform.position * 0 * Time.deltaTime;
        AudioManager.Instance.PlaySound(DeathSound);
         FindObjectOfType<GameManagerLevel2>().GameOver();
    }
}
