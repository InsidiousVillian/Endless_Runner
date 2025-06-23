using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    public AudioClip DeathSound;
    public float countdownTime = 10f;
    public GameManager gameManager;
    private bool isDead;
    public Transform player;

    private int lastSecond = -1;
    private bool isAlive = true;
    public float moveSpeed;

    public TextMeshProUGUI countdownText;
    
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

            if (!isAlive) return;

    
        countdownTime -= Time.deltaTime;
        if (countdownTime < 0f)
        {
            countdownTime = 0f;
            SceneManager.LoadScene("MAIN GAME LEVEL");
        }

        int currentSecond = Mathf.FloorToInt(countdownTime);
        if (currentSecond != lastSecond)
        {
            lastSecond = currentSecond;
            countdownText.text = "Time remaining: " + currentSecond + "s";
        }
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
