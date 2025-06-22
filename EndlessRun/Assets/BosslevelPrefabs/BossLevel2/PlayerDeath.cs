using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioClip DeathSound;
    public GameManager gameManager;
    public bool isDead;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sherif") && !isDead)
        {
            Die();
            //break; // Exit the loop once collision is detected with an obstacle
            gameManager.gameOver();
        }
        if (collision.gameObject.CompareTag("Building") && !isDead)
        {
            Die();
            //break; // Exit the loop once collision is detected with an obstacle
            gameManager.gameOver();
        }
    }
    void Die()
    {
        isDead = true;
        gameManager.gameOver();
        Debug.Log("Player died!");
        // Destroy the player game object or implement your death logic here
        Destroy(player);
        AudioManager.Instance.PlaySound(DeathSound);
    }
}
