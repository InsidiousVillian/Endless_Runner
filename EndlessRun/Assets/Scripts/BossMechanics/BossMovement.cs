using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public AudioClip DeathSound;
    public GameManager gameManager;
    private bool isDead;
    public Transform player;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
                    transform.position,
                    player.position,
                    moveSpeed * Time.deltaTime
            );
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            Die();
            gameManager.gameOver();
            Debug.Log("Sherif");
        }
        if (other.gameObject.CompareTag("Sherif"))
        {
            Die();
            gameManager.gameOver();
            Debug.Log("Sherif");
        }
    }
    void Die()
    {
        isDead = true;
        gameManager.gameOver();
        Debug.Log("Player died!");
        // Destroy the player game object or implement your death logic here
        Destroy(gameObject);
        AudioManager.Instance.PlaySound(DeathSound);
    }
}
